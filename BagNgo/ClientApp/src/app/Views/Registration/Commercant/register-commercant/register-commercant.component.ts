import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { CommercantModel } from 'src/app/Models/commercant.model';

import { AuthService } from '../../../../Services/Auth.service';

@Component({
  selector: 'app-register-commercant',
  templateUrl: './register-commercant.component.html',
  styleUrls: ['./register-commercant.component.scss'],
})
export class RegisterCommercantComponent implements OnInit {
  constructor(
    private fb: FormBuilder,
    private route: Router,
    private securityService: AuthService
  ) {}
 
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
    Patente: Blob,
    FormeJuridique: '',
    NomJuridique: '',
    RNE: Blob,
    CodePostale: '',
    NumCnss: null,
    TypeService: '',
    NumPersAcontacter: null,
    DomainActivite: '',
    Cad: '',
    clientURI: 'http://localhost:4200/emailconfirmation',

  });
  ngOnInit() {}

  register() {
    this.securityService.registerComm(this.userForm.value).subscribe((data) => {
      this.route.navigate(['login']);
    });
  }
}
