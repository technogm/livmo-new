import { Component, OnInit } from '@angular/core';
import { ExperienceService } from 'src/app/Services/experience.service';
import { Router, ActivatedRoute } from '@angular/router';
import { HostServiceService } from 'src/app/Services/host.service';

@Component({
  selector: 'app-profil',
  templateUrl: './profil.component.html',
  styleUrls: ['./profil.component.css']
})
export class ProfilComponent implements OnInit {
  name: any;
  a: any;
  profil: any;
  dataArray: any;
  id: any = localStorage.getItem("ID");
  role: any = localStorage.getItem("UserRole");
  photoLink: any;
  country: any;
  user: any;
  isValid: false;
  experiencePhotos: any;

  constructor(private HostService: HostServiceService, private experienceService: ExperienceService, private router: Router, private activatedRoute: ActivatedRoute) {

    this.HostService.getHostById(this.id).subscribe(data => {
      this.user = data;

      this.name = this.user.legalName;
      this.photoLink = this.user.photoLink;

    })
    this.activatedRoute.params.subscribe(

      (reponse) => {
        this.experienceService.getHostsExperiece(reponse['id']).subscribe(data => {

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
    )

  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(

      (reponse) => {
        this.HostService.getHostById(reponse['id']).subscribe(
          (reponse: any) => {
            this.profil = reponse;
            this.name = this.profil.legalName;
            this.photoLink = this.profil.photoLink;
            this.country = this.profil.country;


            console.log("profil", this.profil)

          },
          (error) => {
            console.log("Error with getById");

          }
        );

      }

    )
  }
  goToDetails(a: any) {
    this.router.navigate(['aboutExperience', a]);
  }

}
