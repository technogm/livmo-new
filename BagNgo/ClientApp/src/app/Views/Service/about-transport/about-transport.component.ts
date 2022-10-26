import { Component, OnInit } from '@angular/core';
import { CommercantService } from 'src/app/Services/commercant.service';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { DatePipe } from '@angular/common';
//import { CommercantService } from './commercant.service';

import { Router, ActivatedRoute } from '@angular/router';
import { ServicesCommercantService } from 'src/app/Services/services-commercant.service';

@Component({
  selector: 'app-about-transport',
  templateUrl: './about-transport.component.html',
  styleUrls: ['./about-transport.component.css'],
  providers: [DatePipe]
})
export class AboutTransportComponent implements OnInit {
  transport: any
  shouldAuth: boolean = false;
  start: Date = new Date();
  end: Date = new Date();

  num: any = 1;
  totalPrice: any = 0;
  // dateArrive:Date=new Date();
  //dateIntervalle: Date[]=[new Date(),new Date()];
  //duration:any=0;
  dateA: any;
  dateB: any;
  aa: any;

  transportPhotos: [];
  nameCommercant: any;
  emailCommercant: any;
  telephoneCommercant: any;
  Commercantt: any;
  fruits: string[] = [];
  themes = [];
  reserveForm: FormGroup;
  reserveForm2: FormGroup;
  duration: any;



  numClient: any = 0;
  username: string = '';

  display: boolean = false;

  constructor(private datePipe: DatePipe, private CommercantService: CommercantService, private fb: FormBuilder, private ServiceService: ServicesCommercantService, private router: Router, private activatedRoute: ActivatedRoute) { }


  ngOnInit(): void {
    this.reserveForm = this.fb.group({
      "start": [''],
      "end": [''],

    })






    this.activatedRoute.params.subscribe(

      (reponse) => {
        this.ServiceService.getTrasportById(reponse['id']).subscribe(
          (reponse: any) => {
            this.transport = reponse;

            console.log("tt", this.transport)
            //console.log("experience id",this.experience.experienceId)
            //console.log("id host id",this.experience.hostId)
          },
          (error) => {
            console.log("Error with getById");

          }
        );

        //console.log("il userrrr",this.EditedPers)
      })



    this.activatedRoute.params.subscribe(
      (reponse) => {
        this.ServiceService.getTransportPhotosById(reponse['id']).subscribe(
          (reponse: any) => {
            this.transportPhotos = reponse;

            console.log("transportPhotos", this.transportPhotos)
            //console.log("typeExperience",typeof this.experiencePhotos)
            for (let i = 0; i < this.transportPhotos.length; i++) {
              console.log("photo no.", this.transportPhotos[i]);
              this.fruits.push(this.transportPhotos[i])
              console.log("fruit.", this.fruits)
              this.aa = this.fruits[0]
              // console.log ("aa." ,this.aa)
              this.themes = [{
                id: 0,

                image: this.fruits[0],
              },
              {
                id: 1,

                image: this.fruits[1],
              },
              {
                id: 2,

                image: this.fruits[2],
              },
              {
                id: 3,

                image: this.fruits[3],
              },


              ]
            }
            console.log("aa.", this.themes)


          },
          (error) => {
            console.log("Error with getById");

          }
        );

      })
  }
  bookNow() {
    var Time = this.end.getTime() - this.start.getTime();
    this.duration = Math.round(Time / (1000 * 3600 * 24));
    console.log("duration", this.duration)
    if (localStorage.getItem("auth-token") === null) {
      this.shouldAuth = true;
    }
    else if (localStorage.getItem("UserRole") == 'Commercant') //client 
    {
      this.display = true;
      console.log('number of clients ', this.num);
      this.totalPrice = this.duration * this.transport.pricePerDay;
      console.log('totalPrice', this.totalPrice);
      //this.dateA = this.datePipe.transform( this.dateArrive,'yyyy-MM-dd ');
      console.log('end', this.end);
      console.log('start', this.start);
    }
  }
}
