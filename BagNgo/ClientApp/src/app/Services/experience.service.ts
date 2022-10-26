import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';



const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Access-Control-Allow-Credentials' : 'true',
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Methods': 'GET, POST, PATCH, DELETE, PUT, OPTIONS',
    'Access-Control-Allow-Headers': 'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With',
  })
  
};
@Injectable({
  providedIn: 'root'

})
export class ExperienceService {
  

  readonly rootUrl = environment.apiUrl + "/Experience";
  readonly rootUrl2 = environment.apiUrl + "/Services";
  readonly rootUrlRes = environment.apiUrl + "/Reservation";
  constructor(private http: HttpClient, private router: Router  ) { }
  getJWT() {
    return {
      headers: {
        Authorization: "Bearer " + localStorage.getItem("auth-token"),
      },
    };
  }
  cl = localStorage.getItem('ID');
  SaveExperience(cl : any,data){
    return this.http.post(this.rootUrl + '/CreateExperience?id='+ cl, data);
  }
  SaveActivity(ExpId : any,data){
    return this.http.post(this.rootUrl + '/AddActivity?expId='+ ExpId,data);
  }
  
  SaveActivityImg(ActId : any, file){
    const formData = new FormData()
    formData.append('file',file)
    return this.http.post(this.rootUrl + '/AddActPhoto?activityId='+ ActId,formData);
  }
  // Lodging :

  SaveLodgigngs(ExpId : any,data){
    return this.http.post(this.rootUrl + '/AddLodging?expId='+ ExpId,data);
  }
  
  SaveLodgingsImg(ActId : any, file){
    const formData = new FormData()
    formData.append('file',file)
    return this.http.post(this.rootUrl + '/AddLodgPhoto?activityId='+ ActId,formData);
  }
  // Transport

  
  SaveTransport(ExpId : any,data){
    return this.http.post(this.rootUrl + '/AddTransport?expId='+ ExpId,data);
  }
  
  SaveTransportImg(ActId : any, file){
    const formData = new FormData()
    formData.append('file',file)
    return this.http.post(this.rootUrl + '/AddTransPhoto?activityId='+ ActId,formData);
  }

  // Food

  SaveFood(ExpId : any,data){
    return this.http.post(this.rootUrl + '/AddFood?expId='+ ExpId,data);
  }
  
  SaveFoodImg(ActId : any, file){
    const formData = new FormData()
    formData.append('file',file)
    return this.http.post(this.rootUrl + '/AddFoodPhoto?activityId='+ ActId,formData);
  }
  ///////////
  SaveExpImg(ExpId : any,file){   
    const formData = new FormData()
    formData.append('file',file)
    return this.http.post(this.rootUrl + '/AddPExphoto?ExperienceID='+ ExpId,formData);
  }

  getHostsExperiece(id){
    return this.http.get(this.rootUrl + '/GetAllHostsExperiences/'+id, {responseType: 'json'});
  }
  getAllExperieces(){
    return this.http.get(this.rootUrl + '/GetAllExperiences/', {responseType: 'json'});
  }
  getAllValidExperieces(){
    return this.http.get(this.rootUrl + '/GetAllValidExperiences/', {responseType: 'json'});
  }
  


  SaveExperienceDates(ActId : any,data){
    return this.http.post(this.rootUrl + '/AddDatesForExperience?expId='+ ActId,data);
  }
  
  //GetAllActiveExperiences

  deleteExperience(id){
    return this.http.delete(this.rootUrl + '/DeleteExperienceById/'+id, {responseType: 'json'});
  }
  getExperienceById(id){
    return this.http.get(this.rootUrl + '/GetExperienceById/'+id);
  }
  getExperiencePhotosById(id){
    return this.http.get(this.rootUrl + '/GetAllLinksURL?id='+id,{responseType: 'json'});
  }
  getExperiencePicsIDs(id){
    return this.http.get(this.rootUrl + '/GetAllExperiencePhotosIDS?id='+id,{responseType: 'json'});
  }
  deleteExperiencePhotos(id){
    return this.http.delete(this.rootUrl + '/deleteExpPhoto?photoId='+id, {responseType: 'json'});
  }

  // Activity ::
  getActivitiesForExperience(id){
    return this.http.get(this.rootUrl + '/GetActivityForSpecificExperience?ExpId='+id,{responseType: 'json'});
  }
  getActivitiesPicsIDs(id){
    return this.http.get(this.rootUrl + '/GetAllActivityIDS?id='+id,{responseType: 'json'});
  }
 
  deleteActivityPhotos(id){
    return this.http.delete(this.rootUrl + '/deleteActPhoto?photoId='+id, {responseType: 'json'});
  }

  // FOOD ::
  getFoodForExperience(id){
    return this.http.get(this.rootUrl + '/GetFoodForSpecificExperience?ExpId='+id,{responseType: 'json'});
  }
  getFoodPicsIDs(id){
    return this.http.get(this.rootUrl + '/GetAllFoodExperienceIDS?id='+id,{responseType: 'json'});
  }
 
  deleteFoodPhotos(id){
    return this.http.delete(this.rootUrl + '/deleteLFoodPhoto?photoId='+id, {responseType: 'json'});
  }

   // Transport ::
   getTransportForExperience(id){
    return this.http.get(this.rootUrl + '/GetTransportForSpecificExperience?ExpId='+id,{responseType: 'json'});
  }
  getTransportPicsIDs(id){
    return this.http.get(this.rootUrl + '/GetAllTransportExperienceIDS?id='+id,{responseType: 'json'});
  }
 
  deleteTransportPhotos(id){
    return this.http.delete(this.rootUrl + '/deleteLTransPhoto?photoId='+id, {responseType: 'json'});
  }

   // Lodging ::
   getLodgingForExperience(id){
    return this.http.get(this.rootUrl + '/GetLodgingForSpecificExperience?ExpId='+id,{responseType: 'json'});
  }
  getLodgingPicsIDs(id){
    return this.http.get(this.rootUrl + '/GetAllLodgingExperienceIDS?id='+id,{responseType: 'json'});
  }
 
  deleteLodgingPhotos(id){
    return this.http.delete(this.rootUrl + '/deleteLdogPhoto?photoId='+id, {responseType: 'json'});
  }
  
  // Reservations : 

  getClientExperienceReservation(id) {
    return this.http.get(this.rootUrlRes + '/GetClientExperienceReservation?id='+id, {responseType: 'json'});
  }
}


