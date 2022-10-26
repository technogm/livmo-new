export interface LoginViewModel {

    Email : string;
    Password : string;
    rememberMe : boolean;

}

export interface AuthenticationResponseViewModel {

    token : string;
    expiration : Date;
    role : string;
    id : string;

}
