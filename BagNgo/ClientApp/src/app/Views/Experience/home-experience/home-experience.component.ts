import { Component, OnInit } from '@angular/core';
import { ExperienceService } from 'src/app/Services/experience.service';
import { Router, ActivatedRoute } from '@angular/router';



@Component({
  selector: 'app-home-experience',
  templateUrl: './home-experience.component.html',
  styleUrls: ['./home-experience.component.css']
})
export class HomeExperienceComponent implements OnInit {
  statut: any = "deslike";
  dataArray: any;
  experiencePhotos: any;
  display: boolean = false;
  dataFilter: any = ["Where", "Whene", "People", "City", "Theme", "Sub-Theme", "Season", "Price min", "Price max"];


  constructor(private experienceService: ExperienceService, private router: Router, private activatedRoute: ActivatedRoute) {
    //this.dataFilter=["Where","Whene","People","City","Theme","Sub-Theme","Season","Price min","Price max"];


    let favourites: { [key: string]: boolean } = {};
    //add all id experience in key and value will be false 
    //then make true when click of like 


    this.experienceService.getAllValidExperieces().subscribe(data => {

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
  like(a: any): void {
    this.statut = 'like';



  }
  deslike(a: any): void {
    this.statut = 'deslike';



  }
  showDialog() {
    this.display = true;
  }

  closeDialog() {
    this.display = false
  }
  deleteImg(indexx) {
    const index: number = this.dataFilter.indexOf(indexx);
    if (index !== -1) {
      this.dataFilter.splice(index, 1);
    }
    console.log(this.dataFilter)
  }
  goToDetails(a: any) {
    this.router.navigate(['aboutExperience', a]);
  }


}
