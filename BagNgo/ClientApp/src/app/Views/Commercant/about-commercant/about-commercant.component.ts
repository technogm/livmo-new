import { Component, OnInit } from '@angular/core';
import { CommercantService } from 'src/app/Services/commercant.service';

import { ExperienceService } from 'src/app/Services/experience.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ServicesCommercantService } from 'src/app/Services/services-commercant.service';



@Component({
  selector: 'app-about-commercant',
  templateUrl: './about-commercant.component.html',
  styleUrls: ['./about-commercant.component.css']
})
export class AboutCommercantComponent implements OnInit {
  isSelected: any = 'ser';
  display: boolean = false;
  displayTransport: boolean = false;
  LastdisplayTransport: boolean = false;
  displayLodging: boolean = false;
  LastdisplayLodging: boolean = false;
  displayFood: boolean = false;
  LastdisplayFood: boolean = false;
  dataTransport: any;
  dataLodging: any;
  dataFood: any;
  id: any = localStorage.getItem("ID");
  role: any = localStorage.getItem("UserRole");
  photoLink: any;
  user: any;
  name: any;
  lodgingPhotos: any;
  transportPhotos: any;
  foodPhotos: any;

  constructor(private ServiceService: ServicesCommercantService, private CommercantService: CommercantService, private router: Router, private activatedRoute: ActivatedRoute) {
    let id = localStorage.getItem("ID");

    this.CommercantService.getCommercantById(id).subscribe(data => {
      this.user = data;

      this.name = this.user.legalName;
      this.photoLink = this.user.photoLink;

    })

    this.ServiceService.getCommTrasports(id).subscribe(data => {

      this.dataTransport = data


      console.log("allTras", this.dataTransport)
      console.log("tras1", this.dataTransport[0])
      for (let i = 0; i < this.dataTransport.length; i++) {
        this.ServiceService.getTransportPhotosById(this.dataTransport[i].transportId).subscribe(
          (reponse: any) => {
            console.log(this.transportPhotos);
            this.transportPhotos = reponse;
            this.dataTransport[i] = { ...this.dataTransport[i], img: this.transportPhotos[0] }

          })
      }
    })
    this.ServiceService.getCommLodgings(id).subscribe(data => {
      this.dataLodging = data
      console.log("allLodging", this.dataLodging)
      console.log("Lodging1", this.dataLodging[0])
      for (let i = 0; i < this.dataLodging.length; i++) {
        this.ServiceService.getLodgingPhotosById(this.dataLodging[i].lodgingId).subscribe(
          (reponse: any) => {
            console.log(this.lodgingPhotos);
            this.lodgingPhotos = reponse;
            this.dataLodging[i] = { ...this.dataLodging[i], img: this.lodgingPhotos[0] }
          })
      }
    })
    this.ServiceService.getCommFoods(id).subscribe(data => {
      this.dataFood = data
      console.log("allFood", this.dataFood)
      console.log("food1", this.dataFood[0])
      for (let i = 0; i < this.dataFood.length; i++) {
        this.ServiceService.getFoodPhotosById(this.dataFood[i].foodServId).subscribe(
          (reponse: any) => {
            console.log(this.foodPhotos);
            this.foodPhotos = reponse;
            this.dataFood[i] = { ...this.dataFood[i], img: this.foodPhotos[0] }

          })
      }
    })
  }
  ngOnInit(): void {

  }
  showDialogTransport() {
    this.displayTransport = true;
  }
  showDialogLodging() {
    this.displayLodging = true;
  }

  showDialogFood() {
    this.displayFood = true;
  }

  showDialog() {
    this.display = true;
  }
  closeDialog() {
    this.display = false
  }
  OpenH(): void {
    this.isSelected = 'ser';
    console.log(this.isSelected);
  }
  OpenR(): void {
    this.isSelected = 'req';
    console.log(this.isSelected);
  }
  OpenF(): void {
    this.isSelected = 'fav';
    console.log(this.isSelected);
  }
  OpenP(): void {
    this.isSelected = 'pro';
    console.log(this.isSelected);
  }
  OpenM(): void {
    this.isSelected = 'msg';
    console.log(this.isSelected);
  }
  goToDetailsT(a: any) {
    this.router.navigate(['aboutTransport', a]);
  }
  goToDetailsL(a: any) {
    this.router.navigate(['aboutLodging', a]);
  }
  goToDetailsF(a: any) {
    this.router.navigate(['aboutFood', a]);
  }

  async DeleteLodging(expID: any) {
    await this.ServiceService.getLodgingPicsIDs(expID).subscribe({
      next: (res: any) => {
        res.forEach(id => {
          this.ServiceService.deleteLodgingPhotos(id).subscribe()
        })
      }
    })
    this.displayLodging = false;
    this.LastdisplayLodging = true;

  }
  async ConfirmeDeleteLodging(id: any) {
    await this.ServiceService.deleteLodging(id).subscribe();
    this.LastdisplayLodging = false; 
    location.reload();

  }
  async DeleteFood(expID: any) {

    await this.ServiceService.getFoodPicsIDs(expID).subscribe({
      next: (res: any) => {
        res.forEach(id => {
          this.ServiceService.deleteFoodPhotos(id).subscribe()
        })
      }
    })
    this.displayFood = false;
    this.LastdisplayFood = true;
  }
  async ConfirmeDeleteFood(id: any) {
    await this.ServiceService.deleteFood(id).subscribe();
    this.LastdisplayFood = false; location.reload();

  }

  async DeleteTransport(expID: any) {
    await this.ServiceService.getTransportPicsIDs(expID).subscribe({
      next: (res: any) => {
        res.forEach(id => {
          this.ServiceService.deleteTransportPhotos(id).subscribe()
        })
      }
    })
    this.displayTransport = false;
    this.LastdisplayTransport = true;
  }
  async ConfirmeDeleteTransport(id: any) {
    await this.ServiceService.deleteTransport(id).subscribe();
    this.LastdisplayTransport = false; location.reload();

  }
}
