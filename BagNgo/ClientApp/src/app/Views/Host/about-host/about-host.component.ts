import { Component, OnInit } from '@angular/core';
import { ExperienceService } from 'src/app/Services/experience.service';
import { Router, ActivatedRoute } from '@angular/router';
import { HostServiceService } from 'src/app/Services/host.service';




@Component({
  selector: 'app-about-host',
  templateUrl: './about-host.component.html',
  styleUrls: ['./about-host.component.css']
})
export class AboutHostComponent implements OnInit {
  experiencePhotos: any;
  isSelected: any = 'exp';
  display: boolean = false;
  name: any;
  showLast: boolean = false;
  user: any;
  dataArray: any;
  id: any = localStorage.getItem("ID");
  role: any = localStorage.getItem("UserRole");
  photoLink: any;
  isValid: false;
  profilePicture = null

  constructor(private HostService: HostServiceService, private experienceService: ExperienceService, private router: Router, private activatedRoute: ActivatedRoute) {
    let id = localStorage.getItem("ID");
    console.log("fafaf", id)

    this.HostService.getHostById(id).subscribe(data => {
      this.user = data;

      this.name = this.user.legalName;
      this.photoLink = this.user.photoLink;

    })

    this.experienceService.getHostsExperiece(id).subscribe(data => {
      this.dataArray = data
      console.log("allEx", this.dataArray)
      console.log("ex1", this.dataArray[0])
      for (let i = 0; i < this.dataArray.length; i++) {


        this.experienceService.getExperiencePhotosById(this.dataArray[i].experienceId).subscribe(
          (reponse: any) => {
            console.log(this.experiencePhotos);
            this.experiencePhotos = reponse;
            this.dataArray[i] = { ...this.dataArray[i], img: this.experiencePhotos[0] }

          })
      }
    })

  }

  ngOnInit(): void {

  }
  OpenE(): void {
    this.isSelected = 'exp';
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
  showDialog() {
    this.display = true;
  }
  async Delete(expID: any) {
    await this.experienceService.getActivitiesForExperience(expID).subscribe({
      next: (res: any) => {
        res.map(e => e.activiteId).forEach(id => {
          this.experienceService.getActivitiesPicsIDs(id).subscribe({
            next: (imgIds: any) =>
              imgIds.forEach(i => this.experienceService.deleteActivityPhotos(i).subscribe())
          })
        }
        )
        console.log("deleted activities");
      }
    })
    await this.experienceService.getFoodForExperience(expID).subscribe({
      next: (res: any) => {
        res.map(e => e.foodId).forEach(id => {
          this.experienceService.getFoodPicsIDs(id).subscribe({
            next: (imgIds: any) =>
              imgIds.forEach(i => this.experienceService.deleteFoodPhotos(i).subscribe())
          })
        }
        )
      }
    })

    // lodging 

    await this.experienceService.getLodgingForExperience(expID).subscribe({
      next: (res: any) => {
        res.map(e => e.lodgingId).forEach(id => {
          this.experienceService.getLodgingPicsIDs(id).subscribe({
            next: (imgIds: any) =>
              imgIds.forEach(i => this.experienceService.deleteLodgingPhotos(i).subscribe())
          })
        }
        )
      }
    })

    // transport 

    await this.experienceService.getTransportForExperience(expID).subscribe({
      next: (res: any) => {
        res.map(e => e.transportId).forEach(id => {
          this.experienceService.getTransportPicsIDs(id).subscribe({
            next: (imgIds: any) =>
              imgIds.forEach(i => this.experienceService.deleteTransportPhotos(i).subscribe())
          })
        }
        )
      }
    })
    await this.experienceService.getExperiencePicsIDs(expID).subscribe({
      next: (res: any) => {
        res.forEach(id => {
          this.experienceService.deleteExperiencePhotos(id).subscribe()
        })
      }
    })
    this.showLast = true;
  }
  closeDialog() {
    this.display = false
  }
  goToDetails(a: any) {
    this.router.navigate(['aboutExperience', a]);
  }
  async DeleteExp(id: any) {
    await this.experienceService.deleteExperience(id).subscribe(response => {
      console.log(response)
      window.location.reload();
      console.log("baaaa ", this.dataArray)
    })
  }
}
