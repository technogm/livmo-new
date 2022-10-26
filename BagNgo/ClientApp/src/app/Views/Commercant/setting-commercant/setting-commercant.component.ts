import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { HttpService } from 'src/app/Services/Http/http.service';
import { CommercantService } from 'src/app/Services/commercant.service';

interface Gouver {
  name: string
}

@Component({
  selector: 'app-setting-commercant',
  templateUrl: './setting-commercant.component.html',
  styleUrls: ['./setting-commercant.component.css']
})
export class SettingCommercantComponent implements OnInit {
  GouverType: Gouver[];
  currentData = null;
  showAlert = false;
  selectedRam: any;
  isSelected: any = 'personal';
  profilePicture = null
  profilePictureFile = null
  CopyIdFile = { name: 'File', data: null }
  CopyIdFile2 = { name: 'File', data: null }
  CopyIdFile3 = { name: 'File', data: null }
  updateForm: FormGroup;
  photoLink: any;
  id: any = localStorage.getItem("ID");

  constructor(private router: Router, private fb: FormBuilder, private http: HttpService, private CommercantService: CommercantService) {
    this.getGouver();
    this.CommercantService.getCommercantById(this.id).subscribe(data => {

      this.currentData = data
      this.photoLink = this.currentData.photoLink
      console.log("commercant", data)
    })
  }

  ngOnInit(): void {

    this.updateForm = this.fb.group({
      "legalName": [''],
      "telephone": [''],
      "contact": [''],
      "country": [''],
      "adresse": [''],
      "delegation": [''],
      "gouvernorate": [''],
      "zipCode": [''],
      "numCnss": [''],
      "femaleWorkforce": [''],
      "maleWorkforce": [''],
      "taxNum": [''],
    })
  }
  setRam(value) {
    this.selectedRam = value;
    console.log(this.selectedRam);
  }
  OpenP(): void {
    this.isSelected = 'personal';
    console.log(this.isSelected);


  }
  OpenF(): void {
    this.isSelected = 'file';
    console.log(this.isSelected);


  }
  OpenC(): void {
    this.isSelected = 'connect';
    console.log(this.isSelected);


  }
  OpenH(): void {
    this.isSelected = 'help';
    console.log(this.isSelected);


  }
  OpenL(): void {
    this.isSelected = 'out';
    console.log(this.isSelected);


  }
  clickFakeUpload(id: any) {
    document.getElementById(id).click()
  }
  uploadedFile(e, id) {
    if (e.target.files && e.target.files[0]) {
      this.profilePictureFile = e.target.files[0];
      const reader = new FileReader();
      reader.onload = e => {
        let data: any = reader.result
        if (this.profilePictureFile.type.indexOf('video') != -1) {
          //if video
        }
        else if (this.profilePictureFile.type.indexOf('image') != -1) {
          if (id == 'profile') {
            this.profilePicture = data
          }
        }
        else if (id == "CopyIdFile") {
          console.log(this.profilePictureFile);
          this.CopyIdFile = { data, name: this.profilePictureFile.name }
        }
        else if (id == "CopyIdFile2") {
          console.log(this.profilePictureFile);
          this.CopyIdFile2 = { data, name: this.profilePictureFile.name }
        }
        else if (id == "CopyIdFile3") {
          console.log(this.profilePictureFile);
          this.CopyIdFile3 = { data, name: this.profilePictureFile.name }
        }
      };
      reader.readAsDataURL(this.profilePictureFile);
    }
  }

  updatenewHost(f: any) {

    let data = f.value
    let gouv;
    let del;
    if (this.currentData.gouvernorate) {
      gouv = this.currentData.gouvernorate.name
    }
    if (this.currentData.delegation) {
      del = this.currentData.delegation.name
    }
    const dataTo = {
      legalName: this.currentData.legalName,
      persAContact: this.currentData.persAContact,
      telephone: this.currentData.telephone,
      adresse: this.currentData.adresse,
      zipCode: this.currentData.zipCode,
      numCnss: this.currentData.numCnss,
      femaleWorkforce: this.currentData.femaleWorkforce,
      maleWorkforce: this.currentData.maleWorkforce,
      taxNum: this.currentData.taxNum,
      gouvernorate: gouv,
      delegation: del,


    };

    let zz = data.legalName

    console.log("to update", dataTo)
    this.CommercantService.updateCommercant(this.id, dataTo).subscribe({
      next: (reponse) => {
        this.showAlert = true;
        this.router.navigate(['/SettingCommercant']);
      },
      error: error => {
        console.log(error);
      }
    });
  }
  logout() {
    localStorage.clear();
    location.reload();
    this.router.navigate(['/homepage']);



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


}
