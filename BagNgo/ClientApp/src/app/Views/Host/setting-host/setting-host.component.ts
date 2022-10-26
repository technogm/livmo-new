import { Component, OnInit } from '@angular/core';
import { SelectItem, PrimeNGConfig } from 'primeng/api';
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { HttpService } from 'src/app/Services/Http/http.service';
import { HostServiceService } from 'src/app/Services/host.service';
import { AuthService } from 'src/app/Services/Auth.service';




@Component({
  selector: 'app-setting-host',
  templateUrl: './setting-host.component.html',
  styleUrls: ['./setting-host.component.css']
})
export class SettingHostComponent implements OnInit {
  currentData = null;
  infoUser = {
    legalName: '',

  };
  CopyFile1 = null
  CopyFile2 = null
  CopyFile3 = null
  showAlert = false;
  showrneAlert = false;
  showlicenceAlert = false;
  isSelected: any = 'personal';
  typeHost: any = '';
  stateOptions: any[];
  value1: string = 'off';
  profilePicture = null
  profilePictureFile = null
  CopyIdFile = { name: 'File', data: null }
  CopyIdFile2 = { name: 'File', data: null }
  CopyIdFile3 = { name: 'File', data: null }
  updateForm: FormGroup;
  updateForm2: FormGroup;
  name: any = '';
  phone: any = '';
  email: any = '';
  country: any = '';
  adresse: any = '';
  cinCopy: any = '';
  rneCopy: any = '';
  licenceCopy: any = '';
  gouvernorate: any = "";
  persAContact : any ="";
  a: any;
  photoLink: any;
  id: any = localStorage.getItem("ID");

  constructor(private primeNGConfig: PrimeNGConfig,
    private router: Router,
    private fb: FormBuilder,
    private http: HttpService,
    private authService: AuthService,
    private HostService: HostServiceService) {
    this.stateOptions = [
      { label: 'Off', value: 'off' },
      { label: 'On', value: 'on' },
    ];

    let id = localStorage.getItem("ID");
    console.log("fafaf", id)
    this.HostService.getHostById(id).subscribe(data => {
      this.a = data;
      this.currentData = data
      this.typeHost = this.a.type
      console.log("user", data)
      //case individual
      this.name = this.a.legalName;
      this.email = this.a.email;
      this.phone = this.a.telephone;
      this.country = this.a.country;
      this.adresse = this.a.adresse;
      this.photoLink = this.a.photoLink;
      this.cinCopy = this.a.cinCopy;
      this.gouvernorate = this.a.gouvernorate;
      this.rneCopy = this.a.rneCopy;
      this.licenceCopy = this.a.licenceCopy;

      console.log("photo", this.photoLink)
      //case organisme
      this.persAContact = this.a.persAContact;
      console.log("usermail :", this.email)
      console.log("cin copy :", this.cinCopy)
      console.log("rne copy :", this.rneCopy)
      console.log("licence copy :", this.licenceCopy)


    })


  }

  ngOnInit(): void {
    this.primeNGConfig.ripple = true;
    //Indiv
    this.updateForm = this.fb.group({
      "legalName": [''],
      "telephone": [''],
      "email": [''],
      "country": [''],
      "adresse": [''],
      "delegation": [''],
      "gouvernorate": [''],
      "cinCopy": [''],
    })
    // organ
    this.updateForm2 = this.fb.group({
      "legalName": [''],
      "telephone": [''],
      "taxNum": [''],
      "femaleWorkforce": [''],
      "maleWorkforce": [''],
      "numCnss": [''],
      "adresse": [''],
      "delegation": [''],
      "gouvernorate": [''],
      "rneCopy": [''],
      "licenceCopy": [''],
      "persAContact": [''],
    })
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
  add(f: any) { }
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
      };
      reader.readAsDataURL(this.profilePictureFile);
    }
  }

  uploadCINFile(e, id) {
    if (e.target.files && e.target.files[0]) {
      this.CopyFile1 = e.target.files[0];
      const reader = new FileReader();
      reader.onload = e => {
        let data: any = reader.result
        if (this.CopyFile1.type.indexOf('image') == -1) {
          if (id == "CopyIdFile") {
            this.CopyIdFile = { data, name: this.CopyFile1.name }
          }
        }
      };
      reader.readAsDataURL(this.CopyFile1);
    }
  }
  uploadRNEFile(e, id) {
    if (e.target.files && e.target.files[0]) {
      this.CopyFile3 = e.target.files[0];
      const reader = new FileReader();
      reader.onload = e => {
        let data: any = reader.result
        if (this.CopyFile3.type.indexOf('image') == -1) {
          if (id == "CopyIdFile3") {
            this.CopyIdFile3 = { data, name: this.CopyFile3.name }
          }
        }
      };
      reader.readAsDataURL(this.CopyFile3);
    }
  }
  uploadLicenceFile(e, id) {
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

  updatenewHost(f: any) {

    let data = f.value
    const dataTo = {
      legalName: this.currentData.legalName,
      telephone: this.currentData.telephone,
      adresse: this.currentData.adresse,
      gouvernorate: this.currentData.gouvernorate,
      delegation: this.currentData.delegation,
      cinCopy: this.currentData.cinCopy,

    };
    try {
      if (this.cinCopyI.value != 'File') {
        console.log(this.CopyIdFile.name);
        this.authService.getCinId(this.id).subscribe({
          next: photoId => this.authService.deleteCIN(photoId, this.email).subscribe()
        });
      }
      console.log("cin deleted success !!")

    } catch (error) {

    }

    console.log("to update", dataTo)
    //this.persServ.updatePersonne(this.EditedPers);
    this.HostService.updateHost(this.id, dataTo).subscribe({
      next: () => {
        this.showAlert = true;
        this.router.navigate(['/setHost']);
      },
      error: error => {
        console.log(error);
      }
    });

  }


  updatenewHost2(f: any) {

    let data = f.value
    const dataTo = {
      legalName: this.currentData.legalName,
      telephone: this.currentData.telephone,
      adresse: this.currentData.adresse,
      gouvernorate: this.currentData.gouvernorate,
      delegation: this.currentData.delegation,
      taxNum: this.currentData.taxNum,
      femaleWorkforce: this.currentData.femaleWorkforce,
      maleWorkforce: this.currentData.maleWorkforce,
      numCnss: this.currentData.numCnss,
      rneCopy: this.currentData.rneCopy,
      licenceCopy: this.currentData.licenceCopy,
    };

    console.log("to update", dataTo)
    this.HostService.updateHost(this.id, dataTo).subscribe({
      next: () => {
        this.showAlert = true;
        this.router.navigate(['/setHost']);
      },
      error: error => {
        console.log(error);
      }
    });
  }
  logout() {
    localStorage.clear();
    location.reload();

    this.router.navigate(['/homepage'])
  }

  deleteProfilePic() {
    this.authService.getProfilePicId(this.id).subscribe({
      next: photoId => this.HostService.deleteImageProfil(photoId, this.email).subscribe()

    });
  }
  changeProfilePic() {
    if (this.photoLink != null)
      this.authService.getProfilePicId(this.id).subscribe({
        next: photoId => this.HostService.deleteImageProfil(photoId, this.email).subscribe()
      });
  }

  AddFiles() {
    this.authService.saveCIN(this.CopyFile1, this.email).toPromise();
    this.showAlert = false;

  }
  DeleteLicence() {
    try {
      if (this.licenceCopyI.value != 'File') {
        console.log(this.CopyIdFile2.name);
        this.authService.getLicenceId(this.id).subscribe({
          next: photoId => this.authService.DeleteLicence(photoId, this.email).subscribe() 
        });
      }
      console.log("licence deleted success !!")
      this.showlicenceAlert = true;
    } catch (error) {

    }

  }

  DeleteRne() {
    try {
      if (this.rneCopyI.value != 'File') {
        console.log(this.CopyIdFile3.name);
        this.authService.getRneId(this.id).subscribe({
          next:  photoId =>  this.authService.deleteRNE(photoId, this.email).subscribe() 
        });
      }
      console.log("rne deleted success !!")
      this.showrneAlert = true;

    } catch (error) {

    }
  }
  AddLicence() {
    this.authService.saveLicence(this.CopyFile2, this.email).toPromise();
    this.showlicenceAlert = false;
  }
  AddRne() {
    this.authService.saveRNE(this.CopyFile3, this.email).toPromise();
    this.showrneAlert = false;

  }
  get cinCopyI() { return this.updateForm.get('cinCopy'); }
  get licenceCopyI() { return this.updateForm2.get('licenceCopy'); }
  get rneCopyI() { return this.updateForm2.get('rneCopy'); }

  async UpdateProfilePic() {
    console.log(this.photoLink);
    console.log("Image not exist")
    this.authService.saveImage(this.profilePictureFile, this.email).toPromise();
    this.router.navigate(['setHost']);

  }
}
