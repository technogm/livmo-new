import { Component, OnInit } from '@angular/core';
import { CommercantService } from 'src/app/Services/commercant.service';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';
import { ServicesCommercantService } from 'src/app/Services/services-commercant.service';

@Component({
  selector: 'app-about-food',
  templateUrl: './about-food.component.html',
  styleUrls: ['./about-food.component.css'],
  providers: [DatePipe],
})
export class AboutFoodComponent implements OnInit {

  food: any
  shouldAuth: boolean = false;
  arrive: Date = new Date();

  num: any = 1;
  totalPrice: any = 0;
  // dateArrive:Date=new Date();
  //dateIntervalle: Date[]=[new Date(),new Date()];
  //duration:any=0;
  dateA: any;
  dateB: any;
  aa: any;

  FoodPhotos: [];
  nameCommercant: any;
  emailCommercant: any;
  telephoneCommercant: any;
  Commercantt: any;
  fruits: string[] = [];
  themes = [];
  reserveForm: FormGroup;
  reserveForm2: FormGroup;



  numClient: any = 0;
  username: string = '';

  display: boolean = false;

  constructor(private datePipe: DatePipe,
    private CommercantService: CommercantService,
    private fb: FormBuilder,
    private ServiceService: ServicesCommercantService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.reserveForm = this.fb.group({
      "arrive": [''],
      "num": [''],
    })
    this.activatedRoute.params.subscribe(

      (reponse) => {
        this.ServiceService.getFoodById(reponse['id']).subscribe(
          (reponse: any) => {
            this.food = reponse;

            console.log("tt", this.food)
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
        this.ServiceService.getFoodPhotosById(reponse['id']).subscribe(
          (reponse: any) => {
            this.FoodPhotos = reponse;

            console.log("foodPhotos", this.FoodPhotos)
            //console.log("typeExperience",typeof this.experiencePhotos)
            for (let i = 0; i < this.FoodPhotos.length; i++) {
              console.log("photo no.", this.FoodPhotos[i]);
              this.fruits.push(this.FoodPhotos[i])
              console.log("fruit.", this.fruits)
              this.aa = this.fruits[0]
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
            console.log("aaaaa.", this.themes)
          },
          (error) => {
            console.log("Error with getById");
          }
        );

      })
  }
  bookNow() {
    if (localStorage.getItem("auth-token") === null) {
      this.shouldAuth = true;
    }
    else if (localStorage.getItem("UserRole") == 'Client') //client 
    {
      this.display = true;
      console.log('number of clients ', this.num);
      this.totalPrice= this.food.foodPrice * this.num;
      console.log('totalPrice', this.totalPrice);
      //this.dateA = this.datePipe.transform( this.dateArrive,'yyyy-MM-dd ');
      console.log('arrive', this.arrive);
      console.log('numclient', this.num);
    }
  }
  //console.log("il userrrr",this.EditedPers)
}
