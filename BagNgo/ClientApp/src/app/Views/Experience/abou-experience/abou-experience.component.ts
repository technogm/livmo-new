import { Component, OnInit } from '@angular/core';
import { ExperienceService } from 'src/app/Services/experience.service';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { DatePipe } from '@angular/common';

import { Router, ActivatedRoute } from '@angular/router';
import { HostServiceService } from 'src/app/Services/host.service';


@Component({
  selector: 'app-abou-experience',
  templateUrl: './abou-experience.component.html',
  styleUrls: ['./abou-experience.component.css'],
  providers: [DatePipe]
})
export class AbouExperienceComponent implements OnInit {
  experience: any
  shouldAuth: boolean = false;
  starttime: any = ''
  endtime: any = ''
  typeDate: any;
  num: any = 1;
  totalPrice: any = 0;
  dateArrive: Date = new Date();
  dateIntervalle: Date[] = [new Date(), new Date()];
  duration: any = 0;
  dateA: any;
  dateB: any;
  aa: any;
  Bookme : boolean =false;
  experiencePhotos: [];
  namehost: any;
  emailhost: any;
  telephonehost: any;
  countryhost: any;
  hosst: any;
  fruits: string[] = [];
  themes = [];
  reserveForm: FormGroup;
  reserveForm2: FormGroup;



  numClient: any = 0;
  username: string = '';

  display: boolean = false;



  constructor(private datePipe: DatePipe, private HostService: HostServiceService, private fb: FormBuilder, private experienceService: ExperienceService, private router: Router, private activatedRoute: ActivatedRoute) {

  }


  ngOnInit(): void {

    this.reserveForm = this.fb.group({
      "numClient": [''],
      "dateArrive": [''],

    })
    this.reserveForm2 = this.fb.group({
      "numClient": [''],
      "dateIntervalle": [''],
      "starttime": [''],
      "endtime": [''],
      "duration": [''],

    })
    //this.numClient=this.reserveForm.get('numClient')?.value;

    this.activatedRoute.params.subscribe(

      (reponse) => {
        this.experienceService.getExperienceById(reponse['id']).subscribe(
          (reponse: any) => {
            this.experience = reponse;

            console.log("experiencer", this.experience)
            console.log("experience id", this.experience.experienceId)
            console.log("id host id", this.experience.hostId)
          },
          (error) => {
            console.log("Error with getById");

          }
        );

        //console.log("il userrrr",this.EditedPers)
      }
    )

    this.activatedRoute.params.subscribe(
      (reponse) => {
        this.experienceService.getExperiencePhotosById(reponse['id']).subscribe(
          (reponse: any) => {
            this.experiencePhotos = reponse;

            console.log("experiencePhotos", this.experiencePhotos)
            console.log("typeExperience", typeof this.experiencePhotos)
            for (let i = 0; i < this.experiencePhotos.length; i++) {
              console.log("Block statement execution no.", this.experiencePhotos[i]);
              this.fruits.push(this.experiencePhotos[i])
              console.log("fruit.", this.fruits)
              this.aa = this.fruits[0]
              // console.log ("aa." ,this.aa)
              this.themes = [{
                id: 1,
                title: 'Culture',
                image: this.fruits[0],
              },
              {
                id: 2,

                title: 'Event',
                image: this.fruits[1]
              },
              {
                id: 3,

                title: 'Health',
                image: this.fruits[2]
              },
              ]
            }

          },
          (error) => {
            console.log("Error with getById");

          }
        );
        for (let idx in this.experiencePhotos) {
          console.log(`Element at index ${idx}: ${this.experiencePhotos[idx]}`);
        }


        for (let i = 0; i < this.experiencePhotos.length; i++) {
          console.log("Name = ", this.experiencePhotos[i]);
        }

        for (const [key, value] of Object.entries(this.experiencePhotos)) {
          console.log(`${key}: ${value}`);
        }
        for (let item of this.experiencePhotos) {
          console.log('item', item)

        }

        //console.log("il userrrr",this.EditedPers)
      }



    )





    this.activatedRoute.params.subscribe(
      (reponse) => {
        this.experienceService.getExperienceById(reponse['id']).subscribe(
          (reponse: any) => {
            this.experience = reponse;
            this.HostService.getHostById(this.experience.hostId).subscribe(data => {
              this.hosst = data;
              this.namehost = this.hosst.legalName;
              this.emailhost = this.hosst.email;
              this.telephonehost = this.hosst.telephone;
              this.countryhost = this.hosst.country;
              this.telephonehost = this.hosst.telephone;
              this.telephonehost = this.hosst.telephone;
              console.log("tayatata", this.hosst)


            })
          },

        );

        //console.log("il userrrr",this.EditedPers)
      }
    )
  }
  dur() {

    var Time = this.dateIntervalle[1].getTime() - this.dateIntervalle[0].getTime();
    this.duration = Time / (1000 * 3600 * 24);
    console.log("duration", this.duration)
  }
  bookNow() {

    if (localStorage.getItem("auth-token") === null) {
      this.shouldAuth = true;
    }
    else if (localStorage.getItem("UserRole") == 'Host') //client 
    {
      this.display = true;
      this.Bookme == true;
      console.log('number of clients ', this.num);
      this.totalPrice = this.num * this.experience.price;
      console.log('totalPrice', this.totalPrice);
      this.dateA = this.datePipe.transform(this.dateArrive, 'yyyy-MM-dd ');
      console.log('dateAA', this.dateA);
      console.log('starttime', this.starttime);
      console.log('dateintervaaaale', this.datePipe.transform(this.dateIntervalle[0], 'yyyy-MM-dd '));
      console.log('dateintervaaaale2', this.dateIntervalle[1]);
    }

  }
  showDialog() {
    this.display = true;
  }
  goToProfil(a: any) {
    this.router.navigate(['Profil', a]);
  }
  Reserver() {
    // local storage : ID of client !!
    // Getting the ID of the experience
    /* this.activatedRoute.params.subscribe(

      (reponse) => {
        let idEx=reponse['id']}) */
    // Reservation(id,idexp);    
  }
}
