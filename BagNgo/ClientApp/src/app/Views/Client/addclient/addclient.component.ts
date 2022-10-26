import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PrimeNGConfig } from 'primeng/api';
import { HttpService } from 'src/app/Services/Http/http.service';
import { AuthService } from '../../../Services/Auth.service';

@Component({
  selector: 'app-addclient',
  templateUrl: './addclient.component.html',
  styleUrls: ['./addclient.component.css']
})
export class AddclientComponent implements OnInit {
  profilePicture = null
  profilePictureFile = null;
  display: boolean = false;
  datebirth: Date;
  countries: any[];
  selectedCountry: any;
  AddClient: FormGroup;
  Mailexist: any;
   checkingEmailExistance: any
   EmailValid : boolean = false;
 

  constructor(private primengConfig: PrimeNGConfig, private fb: FormBuilder, private route: Router, private securityService: AuthService, private http: HttpService) {
    this.SetupFormControl();
  }

  ngOnInit() {
    this.primengConfig.ripple = true;
    this.getCountries();

  }
  keyup(event: any) {
    clearTimeout(this.checkingEmailExistance)
    this.checkingEmailExistance = setTimeout(async () => {
      var email = this.AddClient.value.email;
      this.Mailexist = await this.securityService.EmailExist(email).toPromise();
      //this.ConfirmedEmail = await this.securityService.EmailConfirmed(email).toPromise();
       
      console.log(this.Mailexist);
    }, 600);
  }
  SetupFormControl() {
    this.AddClient = this.fb.group({
      Id: null,
      "nom": ['', [Validators.required, Validators.pattern("[a-zA-Z ]*")]],
      "prenom": ['', [Validators.required, Validators.pattern("[a-zA-Z ]*")]],
      "telephone": ['', [Validators.required, Validators.pattern("[+()0-9]+")]],
      "email": ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      "confirmPassword": ['', Validators.required],
      "country": ['', Validators.required],
      "adresse": ['', Validators.required],
      password: new FormControl('', [Validators.required, Validators.minLength(8), Validators.pattern("(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$")]),
      "dateOfBirth": ['', Validators.required],
      clientURI: 'http://localhost:4200/emailconfirmation',

    })
  }

  getCountries() {
    this.http.getCountries().subscribe((res: any) => {
      this.countries = res;
    })
  }


  register() {
    var data = { ...this.AddClient.value }
    console.log(this.AddClient.value);
    data.country = this.AddClient.value.country.Name
    console.log(data);

    this.securityService.register(data).subscribe({
      next: async (dataServ: any) => {
        try {
          await this.securityService.saveImage(this.profilePictureFile, data.email).toPromise();
        } catch (error) {
        }
      }, error: error => {
        console.log(error);
      }
    });
    this.EmailValid = true;
  }
  clickFakeUpload(id: any) {
    document.getElementById(id).click()
  }
  uploadedFile(e, id) {
    if (e.target.files && e.target.files[0]) {
      const profilePictureFile = e.target.files[0];
      const reader = new FileReader();
      reader.onload = e => {
        let data: any = reader.result
        if (profilePictureFile.type.indexOf('image') != -1) {
          if (id == 'profile') {
            this.profilePicture = data
          }
        }
      };
      reader.readAsDataURL(profilePictureFile);
    }
  }
  showDialog() {
    this.display = true;
  }
  passwordHave(key) {
    const specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    const val = this.password.value + ''
    if (key == 'lowercase') return val.toUpperCase() != val
    if (key == 'upercase') return val.toLowerCase() != val
    if (key == 'num') return val.split('').find((e: any) => !isNaN(e))
    if (key == 'special') return specialChars.test(val)
    else return true
  }
  MustMatch(password: string, confirmPassword: string) {
    return (AddClient: FormGroup) => {
      const passwordControl = this.AddClient.controls[password];
      const confirmPasswordControl = this.AddClient.controls[confirmPassword];

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
  get nom() { return this.AddClient.get('nom'); }
  get prenom() { return this.AddClient.get('prenom'); }
  get telephone() { return this.AddClient.get('telephone'); }
  get email() { return this.AddClient.get('email'); }
  get password() { return this.AddClient.get('password'); }
  get confirmPassword() { return this.AddClient.get('confirmPassword'); }
  get country() { return this.AddClient.get('country'); }
  get dateOfBirth() { return this.AddClient.get('dateOfBirth'); }
  get adresseO() { return this.AddClient.get('adresse'); }

}
