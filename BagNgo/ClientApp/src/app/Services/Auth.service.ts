import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { HttpHeaders } from "@angular/common/http";
import { from, Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { CustomEncoder } from "../Views/Registration/Client/email-confirmation/custom-encoder";
import { ResetPassword } from "src/app/Models/reset-password";
import { AuthenticationResponseViewModel, LoginViewModel } from "src/app/Models/login-model";
import { forgetPassword } from "src/app/Models/forgot-password";

const TOKEN_KEY = "auth-token";
const TOKEN_EXPIR = "token-exper";
const USER_KEY = "auth-user";
const Role = "UserRole";
const ID = "ID";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  readonly rootUrl = environment.apiUrl + "/ClientControllers";
  readonly rootUrl1 = environment.apiUrl + "/ClientControllers";
  readonly rootUrl3 = environment.apiUrl + "/Admin";
  public isUserConnected = false;
  isAdmin: boolean = false;
  isClient: boolean = false;
  public isHost = false;
  public isComm = false;

  constructor(private http: HttpClient) {
    this.isUserConnected = this.checkIsUserConnected();
    this.isAdmin = this.checkIsAdmin();
    this.isClient = this.checkIsClient();
  }
  getJWT() {
    return {
      headers: {
        Authorization: "Bearer " + localStorage.getItem("auth-token"),
      },
    };
  }
  signOut(): void {
    localStorage.clear();
    this.isUserConnected = false;
  }
  checkIsAdmin() {
    const admin = localStorage.getItem(Role);
    while (admin == "Administrateur" && this.isUserConnected) return true;
  }

  checkIsClient() {
    const client = localStorage.getItem(Role);
    while (client == "Client" && this.isUserConnected) return true;
  }

  public forgotPassword = (route: string, body: forgetPassword) => {
    return this.http.post(
      "http://localhost:5000/api/ClientControllers/ForgotPassword",
      body
    );
  };
  public resetPassword = (route: string, body: ResetPassword) => {
    return this.http.post("http://localhost:5000/api/ClientControllers/ResetPassword", body);
  };

  public saveToken(token: AuthenticationResponseViewModel): void {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem(TOKEN_EXPIR);
    localStorage.removeItem(Role);
    localStorage.removeItem(ID);
    localStorage.setItem(TOKEN_KEY, token.token);
    localStorage.setItem(TOKEN_EXPIR, String(token.expiration));
    localStorage.setItem(Role, String(token.role));
    localStorage.setItem(ID, String(token.id));

    this.isUserConnected = true;
  }

  public getToken(): string | null {
    return localStorage.getItem(TOKEN_KEY);
  }

  public saveUser(user: any): void {
    localStorage.removeItem(USER_KEY);
    localStorage.setItem(USER_KEY, JSON.stringify(user));
  }
  public checkIsUserConnected() {
    // Add api to check for token is valid
    const isValidToken = true;
    return (
      isValidToken &&
      localStorage.getItem(TOKEN_KEY) !== null &&
      localStorage.getItem(TOKEN_KEY) !== undefined
    );
  }
  public getUser(): any {
    const user = localStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user);
    }

    return {};
  }

  register(
    userCredentials
  ) /*: Observable<AuthenticationResponseViewModel>*/ {
    // const headers = new HttpHeaders("Content-Type: application/json");
    return this.http.post(
      /*<AuthenticationResponseViewModel>*/ this.rootUrl + "/RegisterClient",
      userCredentials /*,
      { headers }*/
    );
  }

  public confirmEmail = (token: string, email: string) => {
    let params = new HttpParams({ encoder: new CustomEncoder() });
    params = params.append("token", token);
    params = params.append("email", email);

    console.log("Params");
    console.log(params);

    return this.http.get(
      "http://localhost:5000/api/ClientControllers/EmailConfirmation",
      { params: params, responseType: "text" }
    );
  };

  registerHost(userCredentials) {
    return this.http.post(
      this.rootUrl1 + "/RegisterHost",
      userCredentials,
    );
  }

  deleteImageProfil(idImage,email) {
    return this.http.delete(this.rootUrl + '/DeleteImage?photoId=' +idImage +'&Email=' + email);
  }
  
  EmailExist(email: string)   {
    return  this.http.get(this.rootUrl1 + '/Exist?email=' + email);
  } 
  EmailConfirmed(email: string)   {
    return  this.http.get(this.rootUrl1 + '/ConfirmedEmail?email=' + email);
  } 
  async GetAllHosts()   {
    return await this.http.get(this.rootUrl1 + '/GetAllHosts?').subscribe();

  } 
  saveImage(file,Email) {
    const formData = new FormData()
    formData.append('file',file)
    return this.http.post(
      this.rootUrl1 + "/addPhoto?Email="+Email,
      formData,
    );
  }
  saveCIN(file,Email) {
  
    const formData = new FormData()
    formData.append('file',file)
    return this.http.post(
      this.rootUrl1 + "/AddCINFile?Email="+Email,
      formData,
    );
  }

  saveRNE(file,Email) {
  
    const formData = new FormData()
    formData.append('file',file)
    return this.http.post(
      this.rootUrl1 + "/AddRNEFile?Email="+Email,
      formData,
    );
  }
  saveLicence(file,Email) {
  
    const formData = new FormData()
    formData.append('file',file)
    return this.http.post(
      this.rootUrl1 + "/AddLicenceFile?Email="+Email,
      formData,
    );
  }
  saveTransport(file,Email) {
  
    const formData = new FormData()
    formData.append('file',file)
    return this.http.post(
      this.rootUrl1 + "/AddCADTourisFile?Email="+Email,
      formData,
    );
  }

  registerComm(
    userCredentials) {
    return this.http.post(
      this.rootUrl1 + "/RegisterCommercant",
      userCredentials,
    );
  }
  SaveExperience(UserId : any){
    return this.http.post(this.rootUrl + '/AddExperience'+ UserId, {responseType: 'json'});
  }
  login(
    userCredentials: LoginViewModel
  ): Observable<AuthenticationResponseViewModel> {
    const headers = new HttpHeaders("Content-Type: application/json");
    return this.http.post<AuthenticationResponseViewModel>(
      this.rootUrl + "/LoginClient",
      userCredentials,
      { headers }
    );
  }
  getProfilePicId(id: any){
    return  this.http.get(this.rootUrl3 + '/GetUserPhotoID?Userid=' + id);
  }
  getRneId(id){
    return this.http.get(this.rootUrl3 + '/GetRNEidOfUser?Userid='+id);
  }
  getLicenceId(id){
    return this.http.get(this.rootUrl3 + '/GetLicenceidOfUser?Userid='+id);
  }
  getCinId(id){
    return this.http.get(this.rootUrl3 + '/GetCINidOfUser?Userid='+id);
  }
  getCadId(id){
    return this.http.get(this.rootUrl3 + '/GetCADTransportidOfUser?Userid='+id);
  }

  deleteCIN(idImage,email) {
    return this.http.delete(this.rootUrl1 + '/DeleteCINFile?photoId=' +idImage +'&Email=' + email);
  }
  deleteCAD(idImage,email) {
    return this.http.delete(this.rootUrl1 + '/DeleteCADTransportFile?photoId=' +idImage +'&Email=' + email);
  }
  deleteRNE(idImage,email) {
    return this.http.delete(this.rootUrl1 + '/DeleteRNEFile?photoId=' +idImage +'&Email=' + email);
  }
  DeleteLicence(idImage,email) {
    return this.http.delete(this.rootUrl1 + '/DeleteLicenceFile?photoId=' +idImage +'&Email=' + email);
  }
}
