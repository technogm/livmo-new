import {trigger,state,style,transition,animate} from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SelectItemGroup } from 'primeng/api';
import { AuthService } from 'src/app/Services/Auth.service';
import { HttpService } from 'src/app/Services/Http/http.service';

interface Gouver {
  name: string
}
interface ActivC {
  name: string
}
interface RestaurantType {
  name: string
}
interface restaurantSpeciality {
  name: string
}
interface Delegation {
  name: string
}
@Component({
  selector: 'app-addcommercant',
  templateUrl: './addcommercant.component.html',
  styleUrls: ['./addcommercant.component.css'],
  animations: [
    trigger('errorState', [
        state('hidden', style({
            opacity: 0
        })),
        state('visible', style({
            opacity: 1
        })),
        transition('visible => hidden', animate('400ms ease-in')),
        transition('hidden => visible', animate('400ms ease-out'))
    ])
],
})


export class AddcommercantComponent implements OnInit {

  LodignigActivity: ActivC;
  LodgingAct: ActivC[];
  TransportActivity: ActivC;
  TransportAct: ActivC[];
  RestActivity: ActivC;
  RestAct: ActivC[];
  RestType: RestaurantType;
  Restaurant: RestaurantType[];
  RestSpeciality: restaurantSpeciality;
  Speci: restaurantSpeciality[];


  step = 1
  steplength = 5
  labels = ['Type  Service', 'Account', 'General Informations ', 'Essential Informations', 'Documents']
  isselected = "Transport"
  Form2Transport: FormGroup
  Form3Transport: FormGroup
  Form4Transport: FormGroup
  Form5Transport: FormGroup
  Form2Lodging: FormGroup
  Form3Lodging: FormGroup
  Form4Lodging: FormGroup
  Form5Lodging: FormGroup
  Form2Restaurant: FormGroup
  Form3Restaurant: FormGroup
  Form4Restaurant: FormGroup
  Form5Restaurant: FormGroup


  Mailexist: any;
  checkingEmailExistance: any


  value20: number;
  value21: number ;
  value22: number ;
  isselectedType = "SUARL"
  blockSpace: RegExp = /^[a-zA-z\s]+$/;
  PHONEMASK : string;
  CNSSMASK : string;
  TAXMASK : string;
  SelectedGouver: Gouver;
  GouverType: Gouver[];
  groupedCities: SelectItemGroup[];
  selectedCity3: string;



  countries: any[];
  selectedCountry: any;
  selectedGouvernorate: any;
  cities: any[];

  profilePicture = null
  CopyIdFile = { name: 'File', data: null }
  CopyIdFile2 = { name: 'File', data: null }
  CopyIdFile3 = { name: 'File', data: null }
  ConfirmModal : boolean
  profilePictureFile = null
  CopyFile1 = null
  CopyFile2 = null
  CopyFile3 = null

  constructor(private fb: FormBuilder, private http: HttpService,
    private route: Router,
    private securityService: AuthService) {
    this.SetupFormControl();
    this.getGouver();
    this.getActivities();
    this.getRestActivities();
    this.getLodgActivities();
    this.getRestaurantTypes();
    this.getRestaurantSpeciality();
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
  SetupFormControl() {
    this.Form2Transport = this.fb.group({
      verified: false,
      clientURI: 'http://localhost:4200/emailconfirmation',
      "legalName": ['',Validators.required],
      "persAContact": ['', Validators.required],
      "telephone": ['',Validators.required],
      "email": ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")]],
      "confirmPassword": ['', Validators.required],
      password: new FormControl('', [Validators.required, Validators.minLength(8), Validators.pattern("(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$")]),
    })
    this.Form3Transport = this.fb.group({
      "country": ['Tunisia'],
      "delegation": ['', Validators.required],
      "gouvernorate": ['', Validators.required],
      "adresse": ['', Validators.required],
      "zipCode": ['',Validators.required],
      "MaleWorkforce": ['', Validators.required],
      "FemaleWorkforce": ['', Validators.required],
    })
    this.Form4Transport = this.fb.group({
      "legalStatus": ['', Validators.required],
      "basicActivity": ['', Validators.required],
      "numCnss": ['', Validators.required],
      "taxNum": ['', Validators.required],
    })
    this.Form5Transport = this.fb.group({
      "rneCopy": ['', Validators.required],
      "cadTouristTraansp": ['', Validators.required],
      "licenceCopy": ['', Validators.required],
    })
    // Lodging :
    this.Form2Lodging = this.fb.group({
      verified: false,
      clientURI: 'http://localhost:4200/emailconfirmation',
      "legalName": ['', Validators.required],
      "persAContact": ['', Validators.required],
      "telephone": ['', Validators.required],
      "email": ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      "confirmPassword": ['', Validators.required],
      password: new FormControl('', [Validators.required, Validators.minLength(8), Validators.pattern("(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$")]),
    })
    this.Form3Lodging = this.fb.group({
      "country": ['Tunisia'],
      "delegation": ['', Validators.required],
      "gouvernorate": ['', Validators.required],
      "adresse": ['', Validators.required],
      "zipCode": ['', Validators.required],
      "MaleWorkforce": ['', Validators.required],
      "FemaleWorkforce": ['', Validators.required],
    })
    this.Form4Lodging = this.fb.group({
      "legalStatus": ['', Validators.required],
      "basicActivity": ['', Validators.required],
      "numCnss": ['', Validators.required],
      "taxNum": ['', Validators.required],
    })
    this.Form5Lodging = this.fb.group({
      "rneCopy": ['', Validators.required],
      "licenceCopy": ['', Validators.required],
    })
      // Restaurant :
      this.Form2Restaurant = this.fb.group({
        verified: false,
        clientURI: 'http://localhost:4200/emailconfirmation',
        "legalName": ['', Validators.required],
        "persAContact": ['', Validators.required],
        "telephone": ['', Validators.required],
        "email": ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
        "confirmPassword": ['', Validators.required],
        password: new FormControl('', [Validators.required, Validators.minLength(8), Validators.pattern("(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$")]),
      })
      this.Form3Restaurant = this.fb.group({
        "country": ['Tunisia'],
        "delegation": ['', Validators.required],
        "gouvernorate": ['', Validators.required],
        "adresse": ['', Validators.required],
        "zipCode": ['', Validators.required],
        "MaleWorkforce": ['', Validators.required],
        "FemaleWorkforce": ['', Validators.required],
      })
      this.Form4Restaurant = this.fb.group({
        "legalStatus": ['', Validators.required],
        "basicActivity": ['', Validators.required],
        "numCnss": ['', Validators.required],
        "taxNum": ['', Validators.required],
        "restaurantType": ['', Validators.required],
        "restaurantSpeciality": ['', Validators.required],

      })
      this.Form5Restaurant = this.fb.group({
        "rneCopy": ['', Validators.required],
        "licenceCopy": ['', Validators.required],
      })
  }

  ngOnInit(): void {
    this.groupedCities = [
      {
          label: 'Germany', value: 'de', 
          items: [
              {label: 'Berlin', value: 'Berlin'},
              {label: 'Frankfurt', value: 'Frankfurt'},
              {label: 'Hamburg', value: 'Hamburg'},
              {label: 'Munich', value: 'Munich'}
          ]
      },
      {
          label: 'USA', value: 'us', 
          items: [
              {label: 'Chicago', value: 'Chicago'},
              {label: 'Los Angeles', value: 'Los Angeles'},
              {label: 'New York', value: 'New York'},
              {label: 'San Francisco', value: 'San Francisco'}
          ]
      },
      {
          label: 'Japan', value: 'jp', 
          items: [
              {label: 'Kyoto', value: 'Kyoto'},
              {label: 'Osaka', value: 'Osaka'},
              {label: 'Tokyo', value: 'Tokyo'},
              {label: 'Yokohama', value: 'Yokohama'}
          ]
      }
  ];
  this.getActivities();
  this.getRestActivities();
  this.getLodgActivities();
  this.getRestaurantTypes();
  this.getRestaurantSpeciality();
  }

  clickFakeUpload(id: any) {
    document.getElementById(id).click()
  }

  getlabels() {
    switch (this.isselected) {
      case 'Transport':
        return ['Type  Service', 'Account', 'General Informations ', 'Essential Informations', 'Documents']
      case 'Lodging':
        return ['Type  Service', 'Account', 'General Informations ', 'Essential Informations', 'Documents']
      case 'Restaurant':
        return ['Type  Service', 'Account', 'General Informations ', 'Essential Informations', 'Documents']
    }
  }
  addStepTransport() {
    this.step = this.step + 1;
    this.isselected = 'Transport'
  }
  addStepLodging() {
    this.step = this.step + 1;
    this.isselected = 'Lodging'
  }
  addStepRestaurant() {
    this.step = this.step + 1;
    this.isselected = 'Restaurant'
  }
  
  getRestActivities() {
    this.RestAct = [
      { name: 'Liquor store' },
      { name: 'Coffee Shop' },
      { name: 'Catering service' },
      { name: 'Fast Food' },
      { name: 'Traditional Food' },
    ];
  }
  getLodgActivities() {
    this.LodgingAct = [
      { name: 'Campgrounds and trailer parks' },
      { name: 'Hotels and similar services' },
      { name: 'Tourist and other similar short-term accommodation' },
      { name: 'Housing rental' },
      { name: 'Real estate agency' },    
    ];
  }
  getRestaurantSpeciality() {
    this.Speci = [
      { name: 'Burgers' },
      { name: 'Sushi' },
      { name: 'Traditional' },
      { name: 'Grill' },
    ];
  }
  getRestaurantTypes() {
    this.Restaurant = [
    
      { name: 'Restaurant' },
      { name: 'Resto Bar' },
      { name: 'Fast Food' },
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

  uploadedImage(e, id) {
    if (e.target.files && e.target.files[0]) {
      this.profilePictureFile = e.target.files[0];
      const reader = new FileReader();
      reader.onload = e => {
        let data: any = reader.result
        if (this.profilePictureFile.type.indexOf('image') != -1) {
          if (id == 'profile') {
            this.profilePicture = data
          }
        }
      };
      reader.readAsDataURL(this.profilePictureFile);
    }
  }
  UploadLicenceCopy(e, id) {
    if (e.target.files && e.target.files[0]) {
      this.CopyFile1 = e.target.files[0];
      const reader = new FileReader();
      reader.onload = e => {
        let data: any = reader.result
        if (this.CopyFile1.type.indexOf('image') == -1) {
          if (id == 'CopyIdFile') {
            this.CopyIdFile = { data, name: this.CopyFile1.name }
          }
        }
      };
      reader.readAsDataURL(this.CopyFile1);
    }
  }
  uploadRNECopy(e, id) {
    if (e.target.files && e.target.files[0]) {
      this.CopyFile3 = e.target.files[0];
      const reader = new FileReader();
      reader.onload = e => {
        let data: any = reader.result
        if (this.CopyFile3.type.indexOf('image') == -1) {
          if (id == 'CopyIdFile3') {
            this.CopyIdFile3 = { data, name: this.CopyFile3.name }
          }
        }

      };
      reader.readAsDataURL(this.CopyFile3);
    }
  }
  uploadCADFile(e, id) {
    if (e.target.files && e.target.files[0]) {
      this.CopyFile2 = e.target.files[0];
      const reader = new FileReader();
      reader.onload = e => {
        let data: any = reader.result
        if (this.CopyFile2.type.indexOf('image') == -1) {
          if (id == "CopyIdFile2") {
            this.CopyIdFile2 = { data, name: this.CopyFile2.name }
          }
        }
      };
      reader.readAsDataURL(this.CopyFile2);
    }
  }

  keyupT(event: any) {
    clearTimeout(this.checkingEmailExistance)
    this.checkingEmailExistance = setTimeout(async () => {
      var email = this.Form2Transport.value.email;
      this.Mailexist = await this.securityService.EmailExist(email).toPromise();
      console.log(this.Mailexist);
    }, 600);
  }
  keyupL(event: any) {
    clearTimeout(this.checkingEmailExistance)
    this.checkingEmailExistance = setTimeout(async () => {
      var email = this.Form2Lodging.value.email;
      this.Mailexist = await this.securityService.EmailExist(email).toPromise();
      console.log(this.Mailexist);
    }, 600);
  }
  keyupR(event: any) {
    clearTimeout(this.checkingEmailExistance)
    this.checkingEmailExistance = setTimeout(async () => {
      var email = this.Form2Restaurant.value.email;
      this.Mailexist = await this.securityService.EmailExist(email).toPromise();
      console.log(this.Mailexist);
    }, 600);
  }

  passwordHaveOrgTr(key) {
    const specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    const val = this.passwordT.value + ''
    if (key == 'lowercase') return val.toUpperCase() != val
    if (key == 'upercase') return val.toLowerCase() != val
    if (key == 'num') return val.split('').find((e: any) => !isNaN(e))
    if (key == 'special') return specialChars.test(val)
    else return true
  }
  MustMatchOrg(password: string, confirmPassword: string) {
    return (Form2Transport: FormGroup) => {
      const passwordControl = this.Form2Transport.controls[password];
      const ConfirmpasswordControl = this.Form2Transport.controls[confirmPassword];

      if (ConfirmpasswordControl.errors && ConfirmpasswordControl.errors['MustMatch']) {
        return;
      }
      if (passwordControl.value !== ConfirmpasswordControl.value) {
        ConfirmpasswordControl.setErrors({ MustMatch: true });
      }
      else {
        ConfirmpasswordControl.setErrors(null);
      }
    };
  }
  // Lodging : 
  passwordHaveOrgLo(key) {
    const specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    const val = this.passwordL.value + ''
    if (key == 'lowercase') return val.toUpperCase() != val
    if (key == 'upercase') return val.toLowerCase() != val
    if (key == 'num') return val.split('').find((e: any) => !isNaN(e))
    if (key == 'special') return specialChars.test(val)
    else return true
  }
  MustMatchOrgLo(password: string, confirmPassword: string) {
    return (Form2Lodging: FormGroup) => {
      const passwordControl = this.Form2Lodging.controls[password];
      const ConfirmpasswordControl = this.Form2Lodging.controls[confirmPassword];

      if (ConfirmpasswordControl.errors && ConfirmpasswordControl.errors['MustMatch']) {
        return;
      }
      if (passwordControl.value !== ConfirmpasswordControl.value) {
        ConfirmpasswordControl.setErrors({ MustMatch: true });
      }
      else {
        ConfirmpasswordControl.setErrors(null);
      }
    };
  }
  // Lodging : 
  passwordHaveOrgR(key) {
    const specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    const val = this.passwordR.value + ''
    if (key == 'lowercase') return val.toUpperCase() != val
    if (key == 'upercase') return val.toLowerCase() != val
    if (key == 'num') return val.split('').find((e: any) => !isNaN(e))
    if (key == 'special') return specialChars.test(val)
    else return true
  }
  MustMatchOrgR(password: string, confirmPassword: string) {
    return (Form2Restaurant: FormGroup) => {
      const passwordControl = this.Form2Restaurant.controls[password];
      const ConfirmpasswordControl = this.Form2Restaurant.controls[confirmPassword];

      if (ConfirmpasswordControl.errors && ConfirmpasswordControl.errors['MustMatch']) {
        return;
      }
      if (passwordControl.value !== ConfirmpasswordControl.value) {
        ConfirmpasswordControl.setErrors({ MustMatch: true });
      }
      else {
        ConfirmpasswordControl.setErrors(null);
      }
    };
  }

  getCountries() {
    this.http.getCountries().subscribe((res: any) => {
      this.countries = res;
    })
  }
  register() {
    if (this.isselected == 'Transport') {
      var typeService = 'Transport'
      var data = { ...this.Form2Transport.value,  ...this.Form3Transport.value,  ...this.Form4Transport.value, ...this.Form5Transport.value, typeService }
      data.legalStatus = this.Form4Transport.value.legalStatus;
      data.basicActivity = this.Form4Transport.value.basicActivity.name;
      data.gouvernorate = this.Form3Transport.value.gouvernorate.name;
      data.delegation = this.Form3Transport.value.delegation;


    } 
    else if (this.isselected == 'Lodging') {
      var typeService = 'Lodging'
      var data = { ...this.Form2Lodging.value, ...this.Form3Lodging.value,  ...this.Form4Lodging.value, ...this.Form5Lodging.value, typeService }
      data.legalStatus = this.Form4Lodging.value.legalStatus;
      data.gouvernorate = this.Form3Lodging.value.gouvernorate.name;
      data.delegation = this.Form3Lodging.value.delegation;
      data.basicActivity = this.Form4Lodging.value.basicActivity.name;



    } 
    else if (this.isselected == 'Restaurant') {
      var typeService = 'Restaurant'
      var data = { ...this.Form2Restaurant.value,  ...this.Form3Restaurant.value,  ...this.Form4Restaurant.value, ...this.Form5Restaurant.value, typeService }
      data.legalStatus = this.Form4Restaurant.value.legalStatus;
      data.gouvernorate = this.Form3Restaurant.value.gouvernorate.name;
      data.delegation = this.Form3Restaurant.value.delegation;
      data.basicActivity = this.Form4Restaurant.value.basicActivity.name;
      data.restaurantSpeciality = this.Form4Restaurant.value.restaurantSpeciality.name;
      data.restaurantType = this.Form4Restaurant.value.restaurantType.name;

    } 

    this.securityService.registerComm(data).subscribe({
      next: async (dataServ: any) => {

        try {
          await this.securityService.saveImage(this.profilePictureFile, data.email).toPromise();
        } catch (error) {

        }
        try {
          if (this.CopyFile1)
            await this.securityService.saveLicence(this.CopyFile1, data.email).toPromise();
        } catch (error) {

        }

        try {
          if (this.CopyFile2)
            await this.securityService.saveTransport(this.CopyFile2, data.email).toPromise();
        } catch (error) {

        }

        try {
          if (this.CopyFile3)
            await this.securityService.saveRNE(this.CopyFile3, data.email).toPromise();
        } catch (error) {

        }

      },
      error: async () => {
        
        try {
          await this.securityService.saveImage(this.profilePictureFile, data.email).toPromise();
        } catch (error) {

        }
        try {
          if (this.CopyFile1)
            await this.securityService.saveLicence(this.CopyFile1, data.email).toPromise();
        } catch (error) {

        }

        try {
          if (this.CopyFile2)
            await this.securityService.saveTransport(this.CopyFile2, data.email).toPromise();
        } catch (error) {

        }

        try {
          if (this.CopyFile3)
            await this.securityService.saveRNE(this.CopyFile3, data.email).toPromise();
        } catch (error) {

        }
      }
    });
    console.log(data);
    this.ConfirmModal = true;
  }


  NextStepValidation() {
    if (this.isselected == 'Transport') {
      switch (this.step) {
        case 2:
          const passwordValid = this.passwordHaveOrgTr('special') && this.passwordHaveOrgTr('lowercase') && this.passwordHaveOrgTr('upercase') && this.passwordHaveOrgTr('num');
          return this.legalNameT.valid && this.persAContactT.valid && this.telephoneT.valid && this.emailT.valid && (this.confirmPasswordT.value == this.passwordT.value) && passwordValid && !this.Mailexist;;
        case 3:
          return this.gouvernorateT.valid && this.delegationT && this.adresseT.valid && this.zipCodeT.valid && this.FemaleWorkforceT.valid && this.MaleWorkforceT.valid;
        case 4:
          return this.legalStatusT.valid && this.numCnssT.valid && this.taxNumT.valid ;
        case 5:
          return this.rneCopyT.value != 'File' && this.licenceCopyT.value != 'File' && this.cadTouristTraanspT.value != 'File';
        default: return true
      }
    }
    else if (this.isselected == "Lodging") {
      switch (this.step) {
        case 2:
          const passwordValid = this.passwordHaveOrgLo('special') && this.passwordHaveOrgLo('lowercase') && this.passwordHaveOrgLo('upercase') && this.passwordHaveOrgLo('num');
          return this.legalNameL.valid && this.persAContactL.valid && this.telephoneL.valid && this.emailL.valid && (this.confirmPasswordL.value == this.passwordL.value) && passwordValid && !this.Mailexist;;
        case 3:
          return this.gouvernorateL.valid && this.delegationL && this.adresseL.valid && this.zipCodeL.valid && this.FemaleWorkforceL.valid && this.MaleWorkforceL.valid;
        case 4:
          return this.legalStatusL.valid && this.numCnssL.valid && this.taxNumL.valid ;
        case 5:
          return this.rneCopyL.value != 'File' && this.licenceCopyL.value != 'File' ;
        default: return true
      }
    }
    else if (this.isselected == "Restaurant") {
      switch (this.step) {
        case 2:
          const passwordValid = this.passwordHaveOrgR('special') && this.passwordHaveOrgR('lowercase') && this.passwordHaveOrgR('upercase') && this.passwordHaveOrgR('num');
          return this.legalNameR.valid &&  this.telephoneR.valid &&  this.persAContactR.valid && this.emailR.valid && (this.confirmPasswordR.value == this.passwordR.value) && passwordValid && !this.Mailexist;;
        case 3:
          return this.gouvernorateR.valid && this.delegationR && this.adresseR.valid && this.zipCodeR.valid && this.FemaleWorkforceR.valid && this.MaleWorkforceR.valid;
        case 4:
          return this.legalStatusR.valid && this.numCnssR.valid && this.taxNumR.valid ;
        case 5:
          return this.rneCopyR.value != 'File' && this.licenceCopyR.value != 'File' ;
        default: return true
      }
    }
  }
  
  NextStepValidationAction() {
    if (this.isselected == 'Transport') {
      switch (this.step) {
        case 5:
          return  this.rneCopyT.value != 'File' && this.licenceCopyT.value != 'File' && this.cadTouristTraanspT.value != 'File' ;
        default: return true
      }
    }
    else if (this.isselected == "Lodging")
      switch (this.step) {
        case 5: 
        return this.rneCopyL.value != 'File' && this.licenceCopyL.value != 'File' ;
        default: return true
      }
      else if (this.isselected == "Restaurant")
      switch (this.step) {
        case 5: 
        return this.rneCopyR.value != 'File' && this.licenceCopyR.value != 'File' ;
        default: return true
      }
  }
  get legalNameT() { return this.Form2Transport.get('legalName'); }
  get persAContactT() { return this.Form2Transport.get('persAContact'); }
  get telephoneT() { return this.Form2Transport.get('telephone'); }
  get emailT() { return this.Form2Transport.get('email'); }
  get passwordT() { return this.Form2Transport.get('password'); }
  get confirmPasswordT() { return this.Form2Transport.get('confirmPassword'); }
  get gouvernorateT() { return this.Form3Transport.get('gouvernorate'); }
  get countryT() { return this.Form3Transport.get('country'); }
  get delegationT() { return this.Form3Transport.get('delegation'); }
  get adresseT() { return this.Form3Transport.get('adresse'); }
  get zipCodeT() { return this.Form3Transport.get('zipCode'); }
  get MaleWorkforceT() { return this.Form3Transport.get('MaleWorkforce'); }
  get FemaleWorkforceT() { return this.Form3Transport.get('FemaleWorkforce'); }
  get legalStatusT() { return this.Form4Transport.get('legalStatus'); }
  get basicActivityT() { return this.Form4Transport.get('basicActivity'); }
  get taxNumT() { return this.Form4Transport.get('taxNum'); }
  get numCnssT() { return this.Form4Transport.get('numCnss'); }
  get rneCopyT() { return this.Form5Transport.get('rneCopy'); }
  get cadTouristTraanspT() { return this.Form5Transport.get('cadTouristTraansp'); }
  get licenceCopyT() { return this.Form5Transport.get('licenceCopy'); }

  get legalNameL() { return this.Form2Lodging.get('legalName'); }
  get persAContactL() { return this.Form2Lodging.get('persAContact'); }
  get telephoneL() { return this.Form2Lodging.get('telephone'); }
  get emailL() { return this.Form2Lodging.get('email'); }
  get passwordL() { return this.Form2Lodging.get('password'); }
  get confirmPasswordL() { return this.Form2Lodging.get('confirmPassword'); }
  get gouvernorateL() { return this.Form3Lodging.get('gouvernorate'); }
  get countryL() { return this.Form3Lodging.get('country'); }
  get delegationL() { return this.Form3Lodging.get('delegation'); }
  get adresseL() { return this.Form3Lodging.get('adresse'); }
  get zipCodeL() { return this.Form3Lodging.get('zipCode'); }
  get MaleWorkforceL() { return this.Form3Lodging.get('MaleWorkforce'); }
  get FemaleWorkforceL() { return this.Form3Lodging.get('FemaleWorkforce'); }
  get legalStatusL() { return this.Form4Lodging.get('legalStatus'); }
  get basicActivityL() { return this.Form4Lodging.get('basicActivity'); }
  get taxNumL() { return this.Form4Lodging.get('taxNum'); }
  get numCnssL() { return this.Form4Lodging.get('numCnss'); }
  get rneCopyL() { return this.Form5Lodging.get('rneCopy'); }
  get licenceCopyL() { return this.Form5Lodging.get('licenceCopy'); }

  get legalNameR() { return this.Form2Restaurant.get('legalName'); }
  get persAContactR() { return this.Form2Restaurant.get('persAContact'); }
  get telephoneR() { return this.Form2Restaurant.get('telephone'); }
  get emailR() { return this.Form2Restaurant.get('email'); }
  get passwordR() { return this.Form2Restaurant.get('password'); }
  get confirmPasswordR() { return this.Form2Restaurant.get('confirmPassword'); }
  get gouvernorateR() { return this.Form3Restaurant.get('gouvernorate'); }
  get countryR() { return this.Form3Restaurant.get('country'); }
  get delegationR() { return this.Form3Restaurant.get('delegation'); }
  get adresseR() { return this.Form3Restaurant.get('adresse'); }
  get zipCodeR() { return this.Form3Restaurant.get('zipCode'); }
  get MaleWorkforceR() { return this.Form3Restaurant.get('MaleWorkforce'); }
  get FemaleWorkforceR() { return this.Form3Restaurant.get('FemaleWorkforce'); }
  get legalStatusR() { return this.Form4Restaurant.get('legalStatus'); }
  get basicActivityR() { return this.Form4Restaurant.get('basicActivity'); }
  get restaurantTypeR() { return this.Form4Restaurant.get('restaurantType'); }
  get restaurantSpecialityR() { return this.Form4Restaurant.get('restaurantSpeciality'); }
  get taxNumR() { return this.Form4Restaurant.get('taxNum'); }
  get numCnssR() { return this.Form4Restaurant.get('numCnss'); }
  get rneCopyR() { return this.Form5Restaurant.get('rneCopy'); }
  get licenceCopyR() { return this.Form5Restaurant.get('licenceCopy'); }

}
