import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { AuthService } from 'src/app/Services/Auth.service';
import { HttpService } from 'src/app/Services/Http/http.service';
import { ServicesCommercantService } from 'src/app/Services/services-commercant.service';
interface ActivC {
  name: string
}
@Component({
  selector: 'app-add-lodging',
  templateUrl: './add-lodging.component.html',
  styleUrls: ['./add-lodging.component.css']
})
export class AddLodgingComponent implements OnInit {
  LodgingCategort: ActivC;
  Lodging: ActivC[];
  LodgingType: ActivC;
  displayBasic: boolean;
  TypeLodg: ActivC[];
  FormAddLodging: FormGroup;
  ConfirmModal: boolean = false;
  LogPhotos: [];
  expPictures = []


  constructor(private fb: FormBuilder, private http: HttpService,
    private route: Router,
    private securityService: ServicesCommercantService) {
    this.SetupFormControl();
    this.getTypes();
    this.getCategoty();
  }
  SetupFormControl() {
    this.FormAddLodging = this.fb.group({
      "lodgingCategory": ['', Validators.required],
      "lodgingType": ['', Validators.required],
      "lodgingName": ['', Validators.required],
      "lodgingAdress": ['', Validators.required],
      "lodgingWebsite": ['', Validators.required],
      "lodgingDescript": ['', Validators.required],
      "pricePerNight": [null, Validators.required],
    })
  }
  getTypes() {
    this.TypeLodg = [
      { name: 'Hotel' },
      { name: 'Guest House' },
      { name: 'Villa' },
      { name: 'Appartment' },
    ];
  }
  getCategoty() {
    this.Lodging = [
      { name: 'Full Lodging' },
      { name: 'Private Room' },

    ];
  }
  ngOnInit(): void {
    this.SetupFormControl();
    this.getTypes();
    this.getCategoty();

  }

  showBasicDialog() {
    this.displayBasic = true;
  }
  register() {
    var data = { ...this.FormAddLodging.value };
    data.lodgingCategory = this.FormAddLodging.value.lodgingCategory.name;
    data.lodgingType = this.FormAddLodging.value.lodgingType.name;
    data.commercantID = localStorage.getItem('ID');
    // console.log(this.FormAddLodging.value);
    console.log(localStorage.getItem('ID'));

    this.securityService.saveLodging(localStorage.getItem('ID'), data).subscribe({
      next: (exp: any) => {
        const expImageArray = []
        const expImageArray2 = []
        this.expPictures.forEach(img => {
          expImageArray.push(this.securityService.AddLodgingPhotos(exp.lodgingId, img.file))
        })
        forkJoin(expImageArray).subscribe()

      },
      error: (exp: any) => {

      }
    });
    this.ConfirmModal = true;
  }

  NextStepValidation() {


    return this.lodgingCategory.valid && this.lodgingType.valid && this.lodgingName.valid && this.lodgingAdress.valid && this.pricePerNight.value != null && this.lodgingDescript.valid;

  }
  get lodgingCategory() { return this.FormAddLodging.get('lodgingCategory'); }
  get lodgingType() { return this.FormAddLodging.get('lodgingType'); }
  get lodgingName() { return this.FormAddLodging.get('lodgingName'); }
  get lodgingAdress() { return this.FormAddLodging.get('lodgingAdress'); }
  get lodgingWebsite() { return this.FormAddLodging.get('lodgingWebsite'); }
  get pricePerNight() { return this.FormAddLodging.get('pricePerNight'); }
  get lodgingDescript() { return this.FormAddLodging.get('lodgingDescript'); }

}

