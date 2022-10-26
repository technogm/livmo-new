import { i18nMetaToJSDoc } from '@angular/compiler/src/render3/view/i18n/meta';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs/internal/observable/forkJoin';
import { AuthService } from 'src/app/Services/Auth.service';
import { HttpService } from 'src/app/Services/Http/http.service';
import { ServicesCommercantService } from 'src/app/Services/services-commercant.service';

@Component({
  selector: 'app-add-dish',
  templateUrl: './add-dish.component.html',
  styleUrls: ['./add-dish.component.css']
})
export class AddDishComponent implements OnInit {
  priceneDT : string;
  displayBasic : boolean;
  displayBasic2 : boolean;
  FormAddDish : FormGroup;
  rating : number;
  expPictures = []
  expPicturess = []

  ConfirmModal: boolean = false;
  constructor(private fb: FormBuilder, private http: HttpService,
    private route: Router,
    private securityService:ServicesCommercantService ) {
    this.SetupFormControl();
  }
  ngOnInit(): void {
  }
  SetupFormControl() {
    this.FormAddDish = this.fb.group({
      "foodPrice": [null, Validators.required],
      "restaurantName": ['', Validators.required],
      "sologn": ['', Validators.required],
      "openHour": [new Date(), Validators.required],
      "closingHour": [new Date(), Validators.required],
      "dishName": ['', Validators.required],
      "stars": ['', Validators.required],
      "restaurantRules": ['', Validators.required],
      "slogan": ['', Validators.required],
      "adress": ['', Validators.required],
      "website": ['', Validators.required],
      "daysOff": ['', Validators.required],
      "dishDescription": ['', Validators.required],

    })
  }
  showBasicDialog() {
    this.displayBasic = true;
  }
  showBasicDialog1() {
    this.displayBasic2 = true;
  }
  register() { 
      var data = { ...this.FormAddDish.value};
      console.log(this.FormAddDish.value);
      console.log(localStorage.getItem('ID'));
    
      this.securityService.saveFood(localStorage.getItem('ID'), data).subscribe({
        next: (exp: any) => {
          const expImageArray = []           
          const expImageArray2 = []           
          this.expPictures.forEach(img => {
            expImageArray.push(this.securityService.AddFoodphotos(exp.foodServId, img.file))
          })
          forkJoin(expImageArray).subscribe()
          this.expPicturess.forEach(img => {
            expImageArray.push(this.securityService.AddRestphotos(exp.foodServId, img.file))
          })
          forkJoin(expImageArray2).subscribe()
        },
        error: (exp:any) => {
        
        }
      });
    this.ConfirmModal = true;
  }

  NextStepValidation() {
      return this.foodPrice.value != null && this.restaurantName.valid && this.closingHour.valid && this.openHour.valid && this.adress.valid && this.dishDescription.valid && this.dishName.valid
       && this.restaurantRules.valid;
  }
  get foodPrice() { return this.FormAddDish.get('foodPrice'); }
  get restaurantName() { return this.FormAddDish.get('restaurantName'); }
  get sologn() { return this.FormAddDish.get('sologn'); }
  get openHour() { return this.FormAddDish.get('openHour'); }
  get closingHour() { return this.FormAddDish.get('closingHour'); }
  get dishName() { return this.FormAddDish.get('dishName'); }
  get stars() { return this.FormAddDish.get('stars'); }
  get restaurantRules() { return this.FormAddDish.get('restaurantRules'); }
  get slogan() { return this.FormAddDish.get('slogan'); }
  get adress() { return this.FormAddDish.get('adress'); }
  get website() { return this.FormAddDish.get('website'); }
  get daysOff() { return this.FormAddDish.get('daysOff'); }
  get dishDescription() { return this.FormAddDish.get('dishDescription'); }

}
