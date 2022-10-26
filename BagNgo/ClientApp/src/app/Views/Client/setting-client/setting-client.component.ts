import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { HttpService } from 'src/app/Services/Http/http.service';
import { ClientService } from 'src/app/Services/client.service';
import { AuthService } from 'src/app/Services/Auth.service';
import { HostServiceService } from 'src/app/Services/host.service';



@Component({
  selector: 'app-setting-client',
  templateUrl: './setting-client.component.html',
  styleUrls: ['./setting-client.component.css']
})
export class SettingClientComponent implements OnInit {
  currentData = null;
  photoLink : any;
  showAlert = false;
  selectedRam: any;
  isSelected: any = 'personal';
  profilePicture = null
  email : any;
  country : any;
  profilePictureFile = null
  CopyIdFile = { name: 'File', data: null }
  CopyIdFile2 = { name: 'File', data: null }
  CopyIdFile3 = { name: 'File', data: null }
  updateForm: FormGroup;
  id: any = localStorage.getItem("ID");


  constructor(private router: Router, private fb: FormBuilder, private ClientService: ClientService , private authService : AuthService,private HostService: HostServiceService
    ) {
    let id = localStorage.getItem("ID");
    console.log("fafaf", id)
    this.ClientService.getClientById(id).subscribe(data => {

      this.currentData = data
      this.photoLink=this.currentData.photoLink
      this.email = this.currentData.email;
      this.country = this.currentData.country;
      console.log("client connectee est ", data)
    })
  }

  ngOnInit(): void {
    this.updateForm = this.fb.group({

      "nom": [''],
      "prenom": [''],
      "telephone": ['', [Validators.pattern("[+()0-9]+")]],
      "country": [''],
      "dateOfBirth": [''],

    })
  }

  changeProfilePic() {
    if (this.photoLink != null)
      this.authService.getProfilePicId(this.id).subscribe({
        next: photoId => this.HostService.deleteImageProfil(photoId, this.email).subscribe()
      });
  }
  async UpdateProfilePic() {
    console.log(this.photoLink);
    console.log("Image not exist")
    this.authService.saveImage(this.profilePictureFile, this.email).toPromise();
    this.router.navigate(['setClient']);

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
  deleteProfilePic() {
    this.authService.getProfilePicId(this.id).subscribe({
      next : photoId =>  this.authService.deleteImageProfil(photoId,this.email).subscribe()
      
    });
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

  logout() {
    localStorage.clear();
    location.reload();
    this.router.navigate(['/homepage']);

  }
  close(){
    this.showAlert = false;
  }
  updatenewClient(f: any) {

    let data = f.value
    const dataTo = {
      nom: this.currentData.nom,
      prenom: this.currentData.prenom,
      telephone: this.currentData.telephone,
      adresse: this.currentData.adresse,
      dateOfBirth: this.currentData.dateOfBirth,
      country: this.currentData.country,

    };
    console.log("to update", dataTo)
    this.ClientService.updateClient(this.id, dataTo).subscribe({
      next: (reponse) => {
        this.showAlert = true;

        this.router.navigate(['/setClient']);
      },
      error: error => {
        console.log(error);
      }
    });

  }



}
