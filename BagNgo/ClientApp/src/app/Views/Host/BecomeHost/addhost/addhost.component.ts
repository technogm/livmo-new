import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { SelectItemGroup } from 'primeng/api';
import { forkJoin, Observable } from 'rxjs';
import { AuthService } from 'src/app/Services/Auth.service';
import { HttpService } from 'src/app/Services/Http/http.service';

interface Gouver {
  name: string
}
interface Delegation {
  name: string
}
@Component({
  selector: 'app-addhost',
  templateUrl: './addhost.component.html',
  styleUrls: ['./addhost.component.css'],
})


export class AddhostComponent implements OnInit {


  Form2Individual: FormGroup
  Form3Individual: FormGroup

  Mailexist: any;
  checkingEmailExistance: any
  Form2Organisation: FormGroup
  Form3Organisation: FormGroup
  Form4Organisation: FormGroup

  value20: number ;
  value21: number ;
  value22: number;
  alert: boolean = false;
  SelectedGouver: Gouver;
  GouverType: Gouver[];
  displayVerificationI: boolean;
  displayVerificationO: boolean;
  SelectedDeleg: Delegation;
  DelegType: Delegation[];
  CNSSMASK: string;
  TAXMASK: string;
  PHONEMASK: string;
  countries: any[];
  selectedCountry: any;
  blockSpace: RegExp = /^[a-zA-z\s]+$/;

  groupedCities: SelectItemGroup[];
  selectedCity3: string;

  ConfirmModal: boolean = false;
  EmailExistModal: boolean = false;
  constructor(private fb: FormBuilder, private http: HttpService,
    private route: Router,
    private securityService: AuthService) {
    this.SetupFormControl();
    this.getGouver();

  }
  showValidationModal() {
    if (this.isselected == 'individual') {
      this.displayVerificationI = true;
      this.displayVerificationO = false;
      console.log("indiv");
    }
    else {
      this.displayVerificationI = false;
      this.displayVerificationO = true;
      console.log("organ");

    }
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
    this.Form2Organisation = this.fb.group({
      Id: null,
      "legalName": ['', Validators.required],
      "persAContact": ['', Validators.required],
      "telephone": ['', Validators.required],
      "email": ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      "confirmPassword": ['', Validators.required],
      //"country": ['Tunisia', Validators.required],
      "gouvernorate": ['', Validators.required],
      "adresse": ['', Validators.required],
      password: new FormControl('', [Validators.required, Validators.minLength(8), Validators.pattern("(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$")]),
      Verified: false,
      "country": ['Tunisia'],
      clientURI: 'http://localhost:4200/emailconfirmation',

    })
    this.Form3Organisation = this.fb.group({
      "numCnss": ['', Validators.required],
      "TaxNumber": ['', Validators.required],
      "MaleWorkforce": ['', Validators.required],
      "FemaleWorkforce": ['', Validators.required],
    })
    this.Form4Organisation = this.fb.group({
      "rneCopy": ['', Validators.required],
      "licenceCopy": ['', Validators.required],
    })
    this.Form3Individual = this.fb.group({
      "cinCopy": ['', Validators.required],
      "gouvernorate": ['', Validators.required],
      "delegation": ['', Validators.required],
      "zipCode": ['', Validators.required],
      "adresse": ['', Validators.required],
      "country": ['Tunisia'],
    })
    this.Form2Individual = this.fb.group({
      "legalName": ['', Validators.required],
      "telephone": ['', Validators.required],
      "email": ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      "confirmPassword": ['', Validators.required],
      Verified: false,
      clientURI: 'http://localhost:4200/emailconfirmation',
      password: new FormControl('', [Validators.required, Validators.minLength(8), Validators.pattern("(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$")]),
    },
    )
  }
  step = 1
  steplength = 3
  labels = ['Introduction', 'Account', 'Essential Informations']
  isselected = "individual"
  profilePicture = null
  profilePictureFile = null
  CopyFile1 = null
  CopyFile2 = null
  CopyFile3 = null
  CopyIdFile = { name: 'File', data: null }
  CopyIdFile2 = { name: 'File', data: null }
  CopyIdFile3 = { name: 'File', data: null }

  ngOnInit(): void {
    this.groupedCities = [
      {
        label: 'Germany', value: 'de',
        items: [
          { label: 'Ben Arous', value: 'Ben Arous' },
          { label: 'Frankfurt', value: 'Frankfurt' },
          { label: 'Hamburg', value: 'Hamburg' },
          { label: 'Munich', value: 'Munich' }
        ]
      },
      {
        label: 'USA', value: 'us',
        items: [
          { label: 'Chicago', value: 'Chicago' },
          { label: 'Los Angeles', value: 'Los Angeles' },
          { label: 'New York', value: 'New York' },
          { label: 'San Francisco', value: 'San Francisco' }
        ]
      },
      {
        label: 'Japan', value: 'jp',
        items: [
          { label: 'Kyoto', value: 'Kyoto' },
          { label: 'Osaka', value: 'Osaka' },
          { label: 'Tokyo', value: 'Tokyo' },
          { label: 'Yokohama', value: 'Yokohama' }
        ]
      }
    ];
  }
  CloseEmailError() {
    this.EmailExistModal = false;
  }

  keyup(event: any) {
    clearTimeout(this.checkingEmailExistance)
    this.checkingEmailExistance = setTimeout(async () => {
      var email = this.Form2Individual.value.email;
      this.Mailexist = await this.securityService.EmailExist(email).toPromise();
      console.log(this.Mailexist);
    }, 600);
  }
  keyup2(event: any) {
    clearTimeout(this.checkingEmailExistance)
    this.checkingEmailExistance = setTimeout(async () => {
      var email = this.Form2Organisation.value.email;
      this.Mailexist = await this.securityService.EmailExist(email).toPromise();
      console.log(this.Mailexist);
    }, 600);
  }
  register() {
    if (this.isselected == 'organisation') {
      var type = 'organisation'
      var data = {
        ...this.Form2Organisation.value,
        ...this.Form3Organisation.value, ...this.Form4Organisation.value, type
      }
      data.gouvernorate = this.Form2Organisation.value.gouvernorate.name;

    } else {
      var type = 'individual'

      var data = { ...this.Form2Individual.value, ...this.Form3Individual.value, type }
      data.gouvernorate = this.Form3Individual.value.gouvernorate.name;
      data.delegation = this.Form3Individual.value.delegation;
      console.log(this.Form3Individual.value);
    }
    this.securityService.registerHost(data).subscribe({
      next: async (dataServ: any) => {

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
            await this.securityService.saveCIN(this.CopyFile2, data.email).toPromise();
        } catch (error) {

        }

        try {
          if (this.CopyFile3)
            await this.securityService.saveRNE(this.CopyFile3, data.email).toPromise();
        } catch (error) {

        }
      }
    });
    this.ConfirmModal = true;

  }
  getlabels() {
    switch (this.isselected) {
      case 'individual':
        return ['Introduction', 'Account', 'Essential Informations']
      case 'organisation':
        return ['Introduction', 'Account', 'Essential Informations', 'Documents']
      default:
        break;
    }
  }
  clickFakeUpload(id: any) {
    document.getElementById(id).click()
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
  uploadCINFile(e, id) {
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

  getCountries() {
    this.http.getCountries().subscribe((res: any) => {
      this.countries = res;
    })
  }
  passwordHave(key) {
    const specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    const val = this.passwordI.value + ''
    if (key == 'lowercase') return val.toUpperCase() != val
    if (key == 'upercase') return val.toLowerCase() != val
    if (key == 'num') return val.split('').find((e: any) => !isNaN(e))
    if (key == 'special') return specialChars.test(val)
    else return true
  }
  passwordHaveOrg(key) {
    const specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    const val = this.passwordO.value + ''
    if (key == 'lowercase') return val.toUpperCase() != val
    if (key == 'upercase') return val.toLowerCase() != val
    if (key == 'num') return val.split('').find((e: any) => !isNaN(e))
    if (key == 'special') return specialChars.test(val)
    else return true
  }
  MustMatch(password: string, confirmPassword: string) {
    return (Form2Individual: FormGroup) => {
      const passwordControl = this.Form2Individual.controls[password];
      const confirmPasswordControl = this.Form2Individual.controls[confirmPassword];

      if (confirmPasswordControl.errors && confirmPasswordControl.errors['MustMatch']) {
        return;
      }
      if (passwordControl.value !== confirmPasswordControl.value) {
        confirmPasswordControl.setErrors({ MustMatch: true });
      }
      else {
        confirmPasswordControl.setErrors(null);
      }
    };
  }
  MustMatchOrg(password: string, confirmPassword: string) {
    return (Form2Individual: FormGroup) => {
      const passwordControl = this.Form2Individual.controls[password];
      const confirmPasswordControl = this.Form2Organisation.controls[confirmPassword];

      if (confirmPasswordControl.errors && confirmPasswordControl.errors['MustMatch']) {
        return;
      }
      if (passwordControl.value !== confirmPasswordControl.value) {
        confirmPasswordControl.setErrors({ MustMatch: true });
      }
      else {
        confirmPasswordControl.setErrors(null);
      }
    };
  }
  NextStepValidation() {
    if (this.isselected == 'individual') {
      switch (this.step) {
        case 2:
          const passwordValid = this.passwordHave('special') && this.passwordHave('lowercase') && this.passwordHave('upercase') && this.passwordHave('num');
          return this.legalNameI.valid && this.telephoneI.valid && this.emailI.valid && (this.confirmPasswordI.value == this.passwordI.value) && passwordValid && !this.Mailexist;
        case 3:
          return this.cinCopyI.value != 'File' && this.gouvernorateI.valid && this.delegationI.valid && this.adresseI.valid && this.zipCodeI.valid;
        default: return true
      }
    }
    else if (this.isselected == "organisation") {
      switch (this.step) {
        case 2:
          const passwordValid = this.passwordHaveOrg('special') && this.passwordHaveOrg('lowercase') && this.passwordHaveOrg('upercase') && this.passwordHaveOrg('num');
          return this.legalNameO.valid && this.persAContactO.valid && this.gouvernorateO.valid && this.telephoneO.valid && this.adresseO.valid /*&& this.countryO.valid */ && this.emailO.valid && (this.confirmPasswordO.value == this.passwordO.value) && passwordValid && !this.Mailexist;;
        case 3:
          return this.numCnssO.valid && this.TaxNumberO.valid && this.MaleWorkforceO.valid && this.FemaleWorkforceO.valid;
        case 4:
          return this.rneCopyO.value != 'File' && this.licenceCopyO.value != 'File';
        default: return true
      }
    }
    else
      switch (this.step) {
        default: return true
      }
  }
  NextStepValidationAction() {
    if (this.isselected == 'individual') {
      switch (this.step) {
        case 3:
          return /*this.countryI.valid &&*/ this.cinCopyI.valid && this.adresseI.valid && this.countryI.valid
            && this.delegationI.valid && this.adresseI.valid && this.zipCodeI.valid;
        default: return true
      }
    }
    else if (this.isselected == "organisation")
      switch (this.step) {
        case 4:
          return this.rneCopyO.value != 'File' && this.licenceCopyO.value != 'File';
        default: return true
      }
  }
  get legalNameO() { return this.Form2Organisation.get('legalName'); }
  get persAContactO() { return this.Form2Organisation.get('persAContact'); }
  get telephoneO() { return this.Form2Organisation.get('telephone'); }
  get emailO() { return this.Form2Organisation.get('email'); }
  get passwordO() { return this.Form2Organisation.get('password'); }
  get confirmPasswordO() { return this.Form2Organisation.get('confirmPassword'); }
  get countryO() { return this.Form2Organisation.get('country'); }
  get gouvernorateO() { return this.Form2Organisation.get('gouvernorate'); }
  get adresseO() { return this.Form2Organisation.get('adresse'); }

  get numCnssO() { return this.Form3Organisation.get('numCnss'); }
  get TaxNumberO() { return this.Form3Organisation.get('TaxNumber'); }
  get MaleWorkforceO() { return this.Form3Organisation.get('MaleWorkforce'); }
  get FemaleWorkforceO() { return this.Form3Organisation.get('FemaleWorkforce'); }
  get rneCopyO() { return this.Form4Organisation.get('rneCopy'); }
  get licenceCopyO() { return this.Form4Organisation.get('licenceCopy'); }

  get legalNameI() { return this.Form2Individual.get('legalName'); }
  get telephoneI() { return this.Form2Individual.get('telephone'); }
  get emailI() { return this.Form2Individual.get('email'); }
  get passwordI() { return this.Form2Individual.get('password'); }
  get confirmPasswordI() { return this.Form2Individual.get('confirmPassword'); }

  get cinCopyI() { return this.Form3Individual.get('cinCopy'); }
  get countryI() { return this.Form3Individual.get('country'); }
  get gouvernorateI() { return this.Form3Individual.get('gouvernorate'); }
  get delegationI() { return this.Form3Individual.get('delegation'); }
  get zipCodeI() { return this.Form3Individual.get('zipCode'); }
  get adresseI() { return this.Form3Individual.get('adresse'); }

}

