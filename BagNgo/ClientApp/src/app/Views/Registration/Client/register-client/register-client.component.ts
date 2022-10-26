import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ClientModel } from 'src/app/Models/client.model';
import { AuthService } from '../../../../Services/Auth.service';

@Component({
  selector: 'app-register-client',
  templateUrl: './register-client.component.html',
  styleUrls: ['./register-client.component.css'],
})
export class RegisterClientComponent implements OnInit {
  constructor(
    private fb: FormBuilder,
    private route: Router,
    private securityService: AuthService
  ) {}

  ngOnInit() {}

 
  userForm: FormGroup = this.fb.group({
    nom: '',
    prenom: '',
    adresse: '',
    dateOfBirth: '',
    country: '',
    profilePicture: '',
    Email: '',
    password: '',
    confirmPassword: '',
    telephone: '',
    clientURI: 'http://localhost:4200/emailconfirmation',
  });

  register() {
    console.log(this.userForm.value);
    
    // this.securityService.register(this.userForm.value).subscribe((data) => {
    //   this.route.navigate(['login']);
    // });
  }
}
