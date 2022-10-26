import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


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
export class ServicesCommercantService {

  readonly rootUrl2 = environment.apiUrl + "/Services";
  readonly rootUrlRes = environment.apiUrl + "/Reservation";
  constructor(private http: HttpClient, private router: Router) { }
  getJWT() {
    return {
      headers: {
        Authorization: "Bearer " + localStorage.getItem("auth-token"),
      },
    };
  }
  cl = localStorage.getItem('ID');
  saveFood(cl: any, data) {
    return this.http.post(this.rootUrl2 + '/CreateFood?id=' + cl, data);
  }
  saveTransport(cl: any, data) {
    return this.http.post(this.rootUrl2 + '/CreateTransport?id=' + cl, data);
  }
  saveLodging(cl: any, data) {
    return this.http.post(this.rootUrl2 + '/CreateLodging?id=' + cl, data);
  }
  AddFoodphotos(idfood: any, file) {
    const formData = new FormData()
    formData.append('file', file)
    return this.http.post(this.rootUrl2 + '/AddFoodphoto?id=' + idfood, formData);
  }
  AddRestphotos(idfood: any, file) {
    const formData = new FormData()
    formData.append('file', file)
    return this.http.post(this.rootUrl2 + '/AddRestaurantsphoto?id=' + idfood, formData);
  }
  AddLodgingPhotos(idfood: any, file) {
    const formData = new FormData()
    formData.append('file', file)
    return this.http.post(this.rootUrl2 + '/AddLodgingphoto?id=' + idfood, formData);
  }
  AddTransPhotos(idfood: any, file) {
    const formData = new FormData()
    formData.append('file', file)
    return this.http.post(this.rootUrl2 + '/AddTransportphoto?id=' + idfood, formData);
  }


  getCommTrasports(id) {
    return this.http.get(this.rootUrl2 + '/GetAllCommercantTransport/' + id, { responseType: 'json' });
  }
  getAllTrasports() {
    return this.http.get(this.rootUrl2 + '/GetAllTransports/', { responseType: 'json' });
  }
  getTrasportById(id) {
    return this.http.get(this.rootUrl2 + '/GetTransportById/' + id);
  }
  getTransportPicsIDs(id){
    return this.http.get(this.rootUrl2 + '/GetAllTransportIDS?id='+id,{responseType: 'json'});
  }
 
  deleteTransportPhotos(id){
    return this.http.delete(this.rootUrl2 + '/deleteTransportPhoto?photoId='+id, {responseType: 'json'});
  }
  getValidTrasports() {
    return this.http.get(this.rootUrl2 + '/GetAllValidTransports/');
  }
  getTransportPhotosById(id) {
    return this.http.get(this.rootUrl2 + '/GetAllTransportLinksURL?id=' + id, { responseType: 'json' });
  }


  getCommLodgings(id) {
    return this.http.get(this.rootUrl2 + '/GetAllCommercantLodgings/' + id, { responseType: 'json' });
  }
  getAllLodgings() {
    return this.http.get(this.rootUrl2 + '/GetAllLodging/', { responseType: 'json' });
  }

  getLodgingById(id) {
    return this.http.get(this.rootUrl2 + '/GetLodgingById/' + id);
  }

  getLodgingPicsIDs(id){
    return this.http.get(this.rootUrl2 + '/GetAllLodgingIDS?id='+id,{responseType: 'json'});
  }
 
  deleteLodgingPhotos(id){
    return this.http.delete(this.rootUrl2 + '/deleteLodgingPhoto?photoId='+id, {responseType: 'json'});
  }
  getValidLodgings() {
    return this.http.get(this.rootUrl2 + '/GetAllValidLodging/');
  }

  getLodgingPhotosById(id) {
    return this.http.get(this.rootUrl2 + '/GetAllLodgingLinksURL?id=' + id, { responseType: 'json' });
  }


  ///api/Services/GetAllLodgingLinksURL

  deleteFood(id){
    return this.http.delete(this.rootUrl2 + '/DeleteFoodById/'+id, {responseType: 'json'});
  }
  deleteLodging(id){
    return this.http.delete(this.rootUrl2 + '/DeleteLodgingById/'+id, {responseType: 'json'});
  }
  deleteTransport(id){
    return this.http.delete(this.rootUrl2 + '/DeleteTransportById?id='+id, {responseType: 'json'});
  }
  getCommFoods(id) {
    return this.http.get(this.rootUrl2 + '/GetAllCommercantFoods/' + id, { responseType: 'json' });
  }
  getAllFoods() {
    return this.http.get(this.rootUrl2 + '/GetAllFood/', { responseType: 'json' });
  }

  getFoodById(id) {
    return this.http.get(this.rootUrl2 + '/GetFoodById/' + id);
  }


  getValidFoods() {
    return this.http.get(this.rootUrl2 + '/GetAllValidFood/');
  }

  getFoodPicsIDs(id){
    return this.http.get(this.rootUrl2 + '/GetAllFoodIDS?id='+id,{responseType: 'json'});
  }
 
  deleteFoodPhotos(id){
    return this.http.delete(this.rootUrl2 + '/deleteFoodPhoto?photoId='+id, {responseType: 'json'});
  }
  getFoodPhotosById(id) {
    return this.http.get(this.rootUrl2 + '/GetAllFoodLinksURL?id=' + id, { responseType: 'json' });
  }

  // Reservation services :

  getClientFoodReservation(id) {
    return this.http.get(this.rootUrlRes + '/GetClientFoodReservation?id='+id, {responseType: 'json'});
  }
  getClientLodgingReservation(id) {
    return this.http.get(this.rootUrlRes + '/GetClientLodgingReservation?id='+id, {responseType: 'json'});
  }
  GetClientTransportReservation(id) {
    return this.http.get(this.rootUrlRes + '/GetClientTransportReservation?id='+id, {responseType: 'json'});
  }

  DeleteExperienceRes(id){
    return this.http.delete(this.rootUrlRes + '/DeleteExperienceReservationById/'+id, {responseType: 'json'});

  }
  DeleteLodgingRes(id){
    return this.http.delete(this.rootUrlRes + '/DeleteLodgingReservationById/'+id, {responseType: 'json'});

  }
  DeleteFoodRes(id){
    return this.http.delete(this.rootUrlRes + '/DeleteFoodReservationById/'+id, {responseType: 'json'});

  }
  DeleteTransportRes(id){
    return this.http.delete(this.rootUrlRes + '/DeleteTransportReservationById/'+id, {responseType: 'json'});

  }

}

