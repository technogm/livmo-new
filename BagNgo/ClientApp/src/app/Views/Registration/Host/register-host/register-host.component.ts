import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { HostModel } from 'src/app/Models/host.model';
import { AuthService } from '../../../../Services/Auth.service';

@Component({
  selector: 'app-register-host',
  templateUrl: './register-host.component.html',
  styleUrls: ['./register-host.component.scss'],
})
export class RegisterHostComponent implements OnInit {
  userForm: FormGroup = this.fb.group({
    Id: null,
    Nom: '',
    PersAContact: '',
    Telephone: null,
    Country: '',
    Adresse: '',
    Email: '',
    Password: '',
    ConfirmPassword: '',
    Verified: false,
    Type: '',
    EffectHomme: '',
    EffectFemme: '',
    SituationEntreprise: '',
    IdentifiantFiscale: '',
    Patente: null,
    FormeJuridique: '',
    NomJuridique: '',
    RNE: null,
    CodePostale: '',
    NumCnss: null,
    clientURI: 'http://localhost:4200/emailconfirmation',

  });
  constructor(
    private fb: FormBuilder,
    private route: Router,
    private securityService: AuthService
  ) {}

  ngOnInit() {}
  register() {
    this.securityService.registerHost(this.userForm.value).subscribe((data) => {
      this.route.navigate(['login']);
    });
  }
}
