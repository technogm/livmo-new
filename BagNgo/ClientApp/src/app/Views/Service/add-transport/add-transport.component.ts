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
interface Gouver {
  name: string
}

@Component({
  selector: 'app-add-transport',
  templateUrl: './add-transport.component.html',
  styleUrls: ['./add-transport.component.css']
})
export class AddTransportComponent implements OnInit {

  displayBasic : boolean;
  FormAddTransport : FormGroup;
  isselectedType = "Regular"
  TransportActivity: ActivC;
  TransportAct: ActivC[];
  ConfirmModal: boolean = false;
  SelectedGouver: Gouver;
  GouverType: Gouver[];
  expPictures = []
  constructor(private fb: FormBuilder, private http: HttpService,
    private route: Router,
    private securityService: ServicesCommercantService) {
    this.SetupFormControl();
    this.getActivities();
    this.getGouver();
  }

  ngOnInit(): void {
    this.getActivities();
    this.getGouver();
  }
  getGouver() {
    this.GouverType = [
      { name: 'Ariana' },
      { name: 'Béja' },
      { name: 'Ben Arous' },
      { name: 'Bizetre' },
      { name: 'Gabés' },
      { name: 'Gafsa' },
      { name: 'Jendouba' },
      { name: 'Kairouan' },
      { name: 'Kasserine' },
      { name: 'Kebeli' },
      { name: 'Kef' },
      { name: 'Mahdia' },
      { name: 'Manouba' },
      { name: 'Medenine' },
      { name: 'Monastir' },
      { name: 'Nabeul' },
      { name: 'Sfax' },
      { name: 'Sidi Bouzid' },
      { name: 'Siliana' },
      { name: 'Sousse' },
      { name: 'Tataouine' },
      { name: 'Tozeur' },
      { name: 'Tunis' },
      { name: 'Zaghouane' },
    ];
  }
  getActivities() {
    this.TransportAct = [
      { name: 'Regular passenger transport, intercity' },
      { name: 'Private transport' },
      { name: 'Tourist transport' },
      { name: 'Non-regular public transport (“louage”, taxi...)' },
      { name: 'Urban and suburban transport' },
      { name: 'Auxiliary transport service' },
    ];
  }
  SetupFormControl() {
    this.FormAddTransport = this.fb.group({
      "activity": ['', Validators.required],
      "vehuculeName": ['', Validators.required],
      "numberOfSeatd": [null, Validators.required],
      "vehiculeRules": ['', Validators.required],
      "pricePerDay": [null, Validators.required],
      "gouvernorate": [null, Validators.required],
      "type": ['', Validators.required],

    })
  }
  showBasicDialog() {
    this.displayBasic = true;
  }
 
  register() {
    var data = { ...this.FormAddTransport.value };
    data.activity = this.FormAddTransport.value.activity.name;
    data.gouvernorate = this.FormAddTransport.value.gouvernorate.name;
    // console.log(this.FormAddTransport.value);
    console.log(localStorage.getItem('ID'));

    this.securityService.saveTransport(localStorage.getItem('ID'), data).subscribe({
      next: (exp: any) => {
        const expImageArray = []
        const expImageArray2 = []
        this.expPictures.forEach(img => {
          expImageArray.push(this.securityService.AddTransPhotos(exp.transportId, img.file))
        })
        forkJoin(expImageArray).subscribe()

      },
      error: (exp: any) => {

      }
    });
    this.ConfirmModal = true;
  }

  NextStepValidation() {


    return this.activity.valid && this.vehuculeName.valid && this.numberOfSeatd.value !=null && this.vehiculeRules.valid && this.pricePerDay.value != null  && this.type.valid
    && this.gouvernorate.valid;

  }
  get activity() { return this.FormAddTransport.get('activity'); }
  get vehuculeName() { return this.FormAddTransport.get('vehuculeName'); }
  get numberOfSeatd() { return this.FormAddTransport.get('numberOfSeatd'); }
  get vehiculeRules() { return this.FormAddTransport.get('vehiculeRules'); }
  get pricePerDay() { return this.FormAddTransport.get('pricePerDay'); }
  get gouvernorate() { return this.FormAddTransport.get('gouvernorate'); }
  get type() { return this.FormAddTransport.get('type'); }

}

