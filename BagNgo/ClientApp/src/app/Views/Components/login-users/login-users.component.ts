import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/Services/Auth.service';
import { HttpService } from 'src/app/Services/Http/http.service';

@Component({
  selector: 'app-login-users',
  templateUrl: './login-users.component.html',
  styleUrls: ['./login-users.component.css']
})
export class LoginUsersComponent implements OnInit {
  LoginForm: FormGroup
  ConfirmModal : boolean = false;
 // EmailValidModal : boolean = false;
  Mailexist: any;
 // ConfirmedEmail : any;
  checkingEmailExistance: any
  constructor(private fb: FormBuilder, private http: HttpService,
    private route: Router,
    private securityService: AuthService,
    ) {
  }

  ngOnInit(): void {
    this.LoginForm = this.fb.group({
      "email": ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      "password": ['', Validators.required],
    })
  }

  keyup(event: any) {
    clearTimeout(this.checkingEmailExistance)
    this.checkingEmailExistance = setTimeout(async () => {
      var email = this.LoginForm.value.email;
      this.Mailexist = await this.securityService.EmailExist(email).toPromise();
      //this.ConfirmedEmail = await this.securityService.EmailConfirmed(email).toPromise();
       
      console.log(this.Mailexist);
    }, 600);
  }
  
  login () {
    this.securityService.login(this.LoginForm.value).subscribe({
    
        next: async (data: any) => {
 
        console.log("Console data value : ", data);
        this.securityService.saveToken(data);
        // check role
       // this.route.navigate(["homepage"]);
        window.location.reload();
      },
      error: async () => {
        this.ConfirmModal = true;
      } 
    }
    
    );
  }
  routing(path: any) {
    this.route.navigate(["homepage"])
  }
  dashboard(){
    this.route.navigate(["Dashboard"])
    .then(() => {
      window.location.reload();
    });    
  }
  get email() { return this.LoginForm.get('email'); }
  get password() { return this.LoginForm.get('password'); }

}

