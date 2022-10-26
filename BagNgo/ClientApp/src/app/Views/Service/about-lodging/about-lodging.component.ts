import { Component, OnInit } from '@angular/core';
import { CommercantService } from 'src/app/Services/commercant.service';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';
import { ServicesCommercantService } from 'src/app/Services/services-commercant.service';
import { flatMap } from 'rxjs';

@Component({
  selector: 'app-about-lodging',
  templateUrl: './about-lodging.component.html',
  styleUrls: ['./about-lodging.component.css'],
  providers: [DatePipe],
})
export class AboutLodgingComponent implements OnInit {

  lodging: any
  shouldAuth: boolean = false;
  arrive: Date = new Date();
  departure: Date = new Date();
  duration: any

  num: any = 1;
  totalPrice: any = 0;
  dateA: any;
  dateB: any;
  aa: any;
  Bookme : boolean= false;

  lodgingPhotos: [];
  nameCommercant: any;
  emailCommercant: any;
  telephoneCommercant: any;
  Commercantt: any;
  fruits: string[] = [];
  themes = [];
  reserveForm: FormGroup;
  reserveForm2: FormGroup;
  Time : any;
  Days:any; 



  numClient: any = 0;
  username: string = '';

  display: boolean = false;

  constructor(private datePipe: DatePipe, private CommercantService: CommercantService, private fb: FormBuilder, private ServiceService: ServicesCommercantService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.reserveForm = this.fb.group({
      "arrive": [''],
      "departure": [''],
      "num": [''],

    })

    this.activatedRoute.params.subscribe(

      (reponse) => {
        this.ServiceService.getLodgingById(reponse['id']).subscribe(
          (reponse: any) => {
            this.lodging = reponse;

            console.log("tt", this.lodging)
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
        this.ServiceService.getLodgingPhotosById(reponse['id']).subscribe(
          (reponse: any) => {
            this.lodgingPhotos = reponse;

            console.log("lodgingPhotos", this.lodgingPhotos)
            //console.log("typeExperience",typeof this.experiencePhotos)
            for (let i = 0; i < this.lodgingPhotos.length; i++) {
              console.log("photo no.", this.lodgingPhotos[i]);
              this.fruits.push(this.lodgingPhotos[i])
              console.log("fruit.", this.fruits)
              this.aa = this.fruits[0]
              // console.log ("aa." ,this.aa)
              this.themes = [{
                id: i,

                image: this.fruits[i],
              },


              ]
            }


          },
          (error) => {
            console.log("Error with getById");

          }
        );

      })
  }
  
  bookNow() {
    var Time = this.departure.getTime() - this.arrive.getTime();
    this.duration = Math.round(Time / (1000 * 3600 * 24));
    console.log("duration", this.duration)
    if (localStorage.getItem("auth-token") === null) {
      this.shouldAuth = true;
    }
    else if (localStorage.getItem("UserRole") == 'Host') //client 
    {
      this.display = true;
      this.Bookme == true;
      console.log('number of clients ', this.num);
      this.totalPrice = this.duration * this.lodging.pricePerNight * this.num;
      console.log('totalPrice', this.totalPrice);
      console.log('dep', this.departure);
      console.log('arriv', this.arrive);
    }
  }
}

