import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ClientModel } from '../Models/client.model';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Credentials': 'true',
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Methods': 'GET, POST, PATCH, DELETE, PUT, OPTIONS',
    'Access-Control-Allow-Headers': 'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With',
  })
};
@Injectable({
  providedIn: 'root'
})
export class HostServiceService {
  readonly rootUrl = environment.apiUrl + "/Admin";
  readonly rootUrl2 = environment.apiUrl + "/ClientControllers";




  constructor(private http: HttpClient, private router: Router) { }
  getHostById(id) {
    return this.http.get(this.rootUrl + '/GetUserById/' + id);
  }
  updateHost(id: string, newprofile: any) {

    return this.http.put(this.rootUrl2 + '/EditHost/' + id, newprofile);

  }

  deleteImageProfil(idImage,email) {
    return this.http.delete(this.rootUrl2 + '/DeleteImage?photoId=' +idImage +'&Email=' + email);
  }


  getJWT() {
    return {
      headers: {
        Authorization: "Bearer " + localStorage.getItem("auth-token"),
      },
    };
  }
}

