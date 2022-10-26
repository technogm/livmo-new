import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientGuard } from './guards/client.guard';
import { CommercantGuard } from './guards/commercant.guard';
import { ConnectedGuard } from './guards/connected.guard';
import { HostGuard } from './guards/host.guard';
import { AuthGuardGuard } from './Services/auth-guard.guard';
import { AboutClientComponent } from './Views/Client/about-client/about-client.component';
import { AddclientComponent } from './Views/Client/addclient/addclient.component';
import { SettingClientComponent } from './Views/Client/setting-client/setting-client.component';
import { AboutCommercantComponent } from './Views/Commercant/about-commercant/about-commercant.component';
import { AddcommercantComponent } from './Views/Commercant/BecomeCommercant/addcommercant/addcommercant.component';
import { SettingCommercantComponent } from './Views/Commercant/setting-commercant/setting-commercant.component';
import { ProfilComponent } from './Views/Components/profil/profil.component';
import { AbouExperienceComponent } from './Views/Experience/abou-experience/abou-experience.component';
import { AddExperienceComponent } from './Views/Experience/add-experience/add-experience.component';
import { EditExperienceComponent } from './Views/Experience/edit-experience/edit-experience.component';
import { HomeExperienceComponent } from './Views/Experience/home-experience/home-experience.component';
import { HomeComponent } from './Views/home/home.component';
import { UsersDashbaordComponent } from './Views/home/users-dashbaord/users-dashbaord.component';
import { AboutHostComponent } from './Views/Host/about-host/about-host.component';
import { AddhostComponent } from './Views/Host/BecomeHost/addhost/addhost.component';
import { SettingHostComponent } from './Views/Host/setting-host/setting-host.component';
import { NotFoundComponent } from './Views/not-found/not-found.component';
import { EmailConfirmationComponent } from './Views/Registration/Client/email-confirmation/email-confirmation.component';
import { ForgotPasswordComponent } from './Views/Registration/Client/forgot-password/forgot-password.component';
import { LoginClientComponent } from './Views/Registration/Client/login-client/login-client.component';
import { RegisterClientComponent } from './Views/Registration/Client/register-client/register-client.component';
import { ResetPasswordComponent } from './Views/Registration/Client/reset-password/reset-password.component';
import { RegisterCommercantComponent } from './Views/Registration/Commercant/register-commercant/register-commercant.component';
import { RegisterHostComponent } from './Views/Registration/Host/register-host/register-host.component';
import { AboutFoodComponent } from './Views/Service/about-food/about-food.component';
import { AboutLodgingComponent } from './Views/Service/about-lodging/about-lodging.component';
import { AboutTransportComponent } from './Views/Service/about-transport/about-transport.component';
import { AddDishComponent } from './Views/Service/add-dish/add-dish.component';
import { AddLodgingComponent } from './Views/Service/add-lodging/add-lodging.component';
import { AddTransportComponent } from './Views/Service/add-transport/add-transport.component';
import { HomeLodgingComponent } from './Views/Service/home-lodging/home-lodging.component';
import { HomeRestaurantsComponent } from './Views/Service/home-restaurants/home-restaurants.component';
import { HomeTransportComponent } from './Views/Service/home-transport/home-transport.component';

const routes: Routes = [
  { path: "", component: HomeComponent, pathMatch: "full" },

  {
    path: "login",
    component: LoginClientComponent,
    data: { title: "Login Page" },
  },

  {
    path: 'forgotpassword',
    component: ForgotPasswordComponent,
    data: { title: "Forget Password" },
  },
  {
    path: 'resetpassword',
    component: ResetPasswordComponent,
    data: { title: "Reset Password" },
  },

  {
    path: 'emailconfirmation',
    component: EmailConfirmationComponent
  },


  {
    path: "register",
    component: RegisterClientComponent,
    data: { title: "Register Page" },
  },
  {
    path: "register-host",
    component: RegisterHostComponent,
    data: { title: "Register Host" },
  },
  {
    path: "register-commercant",
    component: RegisterCommercantComponent,
    data: { title: "Register Commercant" },
  },
  {
    path: "AddExperience",
    component: AddExperienceComponent,
    canActivate: [HostGuard],
    data: { title: "Add Experience" },
  },
  {
    path: "addClient",
    component: AddclientComponent,
    canActivate: [ConnectedGuard],
    data: { title: "Register Client" },
  },
  {
    path: "addHost",
    component: AddhostComponent,
    canActivate: [ConnectedGuard],
    data: { title: "Add host" },
  },
  {
    path: "addCommercant",
    component: AddcommercantComponent,
    canActivate: [ConnectedGuard],
    data: { title: "Add Commercant" },
  },
  {
    path: "Dashboard",
    component: UsersDashbaordComponent,
    canActivate: [ConnectedGuard],
    data: { title: "Users" },
  },
  {
    path: "AddDish",
    component: AddDishComponent,
    canActivate: [CommercantGuard],
    
    data: { title: "Users" },
  },
  {
    path: "AddTransport",
    component: AddTransportComponent,
    canActivate: [CommercantGuard],
    data: { title: "Users" },
  },
  {
    path: "AddLodging",
    component: AddLodgingComponent,
    canActivate: [CommercantGuard],
    data: { title: "Users" },
  },
  // If route does not exist : Home => Not found component
  { path: "homepage", component: HomeComponent },


  { path: "HomeExperience", component: HomeExperienceComponent },
  { path: "HomeLodging", component: HomeLodgingComponent },
  { path: "HomeTransport", component: HomeTransportComponent },
  { path: "HomeRestaurant", component: HomeRestaurantsComponent },
  { path: "setHost", component: SettingHostComponent, canActivate: [HostGuard] },

  { path: "aboutFood/:id", component: AboutFoodComponent },
  { path: "aboutTransport/:id", component: AboutTransportComponent },
  { path: "aboutLodging/:id", component: AboutLodgingComponent },



  {
    path: "setClient", component: SettingClientComponent, canActivate: [ClientGuard],
  },

  { path: "aboutHost", component: AboutHostComponent, canActivate: [HostGuard] },
  { path: "aboutExperience/:id", component: AbouExperienceComponent },
  { path: "addExperience", component: AddExperienceComponent, canActivate: [HostGuard], },
  { path: "EditExperience", component: EditExperienceComponent ,     canActivate: [HostGuard],},
  { path: "AboutClient", component: AboutClientComponent ,     canActivate: [ClientGuard],},
  { path: "AboutCommercant", component: AboutCommercantComponent ,     canActivate: [CommercantGuard],},
  { path: "SettingCommercant", component: SettingCommercantComponent ,     canActivate: [CommercantGuard],
},



  { path: "Profil/:id", component: ProfilComponent },

  { path: 'not-found', component: NotFoundComponent },
  { path: '**', redirectTo: 'not-found' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
