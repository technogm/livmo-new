import { HttpClientModule } from '@angular/common/http';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './Views/nav-menu/nav-menu.component';
import { EmailConfirmationComponent } from './Views/Registration/Client/email-confirmation/email-confirmation.component';
import { ForgotPasswordComponent } from './Views/Registration/Client/forgot-password/forgot-password.component';
import { LoginClientComponent } from './Views/Registration/Client/login-client/login-client.component';
import { RegisterClientComponent } from './Views/Registration/Client/register-client/register-client.component';
import { ResetPasswordComponent } from './Views/Registration/Client/reset-password/reset-password.component';
import { RegisterCommercantComponent } from './Views/Registration/Commercant/register-commercant/register-commercant.component';
import { RegisterHostComponent } from './Views/Registration/Host/register-host/register-host.component';
import { HomeComponent } from './Views/home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { FooterComponent } from './Views/footer/footer.component';
import { StepperComponent } from './Views/Components/stepper/stepper.component';
import { AddhostComponent } from './Views/Host/BecomeHost/addhost/addhost.component';
import {CarouselModule} from 'primeng/carousel';
import {RadioButtonModule} from 'primeng/radiobutton';
import {KeyFilterModule} from 'primeng/keyfilter';
import {PasswordModule} from 'primeng/password';
import { DividerModule } from "primeng/divider";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {DropdownModule} from 'primeng/dropdown';
import {InputNumberModule} from 'primeng/inputnumber';
import { SteppercomComponent } from './Views/Components/steppercom/steppercom.component';
import { AddcommercantComponent } from './Views/Commercant/BecomeCommercant/addcommercant/addcommercant.component';
import { UsersDashbaordComponent } from './Views/home/users-dashbaord/users-dashbaord.component';
import { AddclientComponent } from './Views/Client/addclient/addclient.component';
import { LoginUsersComponent } from './Views/Components/login-users/login-users.component';
import { StepperexpComponent } from './Views/Components/stepperexp/stepperexp.component';
import { AddExperienceComponent } from './Views/Experience/add-experience/add-experience.component';
import {DialogModule} from 'primeng/dialog';
import {ButtonModule} from 'primeng/button';
import { AddPhotosExpComponent } from './Views/Experience/add-photos-exp/add-photos-exp.component';
import {InputTextareaModule} from 'primeng/inputtextarea';
import { AddActivityComponent } from './Views/Experience/add-activity/add-activity.component';
import {CalendarModule} from 'primeng/calendar';
import {MessageModule} from 'primeng/message';
import {InputMaskModule} from 'primeng/inputmask';
import { CascadeSelectModule } from "primeng/cascadeselect";
import { AutoCompleteModule } from 'primeng/autocomplete';
import {MultiSelectModule} from 'primeng/multiselect';
import { AddDishComponent } from './Views/Service/add-dish/add-dish.component';
import { AddTransportComponent } from './Views/Service/add-transport/add-transport.component';
import { AddLodgingComponent } from './Views/Service/add-lodging/add-lodging.component';
import {RatingModule} from 'primeng/rating';
import { AddFoodComponent } from './Views/Experience/add-food/add-food.component';
import { AddDishPhotosComponent } from './Views/Service/add-dish-photos/add-dish-photos.component';
import { AddLodgingPhotosComponent } from './Views/Service/add-lodging-photos/add-lodging-photos.component';
import { AddRestaurantPhotosComponent } from './Views/Service/add-restaurant-photos/add-restaurant-photos.component';
import { AddTransportPhotosComponent } from './Views/Service/add-transport-photos/add-transport-photos.component';
import { AboutClientComponent } from './Views/Client/about-client/about-client.component';
import { SettingClientComponent } from './Views/Client/setting-client/setting-client.component';
import { SettingCommercantComponent } from './Views/Commercant/setting-commercant/setting-commercant.component';
import { AboutCommercantComponent } from './Views/Commercant/about-commercant/about-commercant.component';
import { ProfilComponent } from './Views/Components/profil/profil.component';
import { AbouExperienceComponent } from './Views/Experience/abou-experience/abou-experience.component';
import { EditExperienceComponent } from './Views/Experience/edit-experience/edit-experience.component';
import { HomeExperienceComponent } from './Views/Experience/home-experience/home-experience.component';
import { AboutHostComponent } from './Views/Host/about-host/about-host.component';
import { SettingHostComponent } from './Views/Host/setting-host/setting-host.component';
import { NotFoundComponent } from './Views/not-found/not-found.component';
import { AboutFoodComponent } from './Views/Service/about-food/about-food.component';
import { AboutLodgingComponent } from './Views/Service/about-lodging/about-lodging.component';
import { AboutTransportComponent } from './Views/Service/about-transport/about-transport.component';
import { AddTransportexpComponent } from './Views/Experience/add-transportexp/add-transportexp.component';
import { AddLodgingexpComponent } from './Views/Experience/add-lodgingexp/add-lodgingexp.component';
import { HomeLodgingComponent } from './Views/Service/home-lodging/home-lodging.component';
import { HomeTransportComponent } from './Views/Service/home-transport/home-transport.component';
import { HomeRestaurantsComponent } from './Views/Service/home-restaurants/home-restaurants.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginClientComponent,
    RegisterClientComponent,
    RegisterCommercantComponent,
    RegisterHostComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    EmailConfirmationComponent,
    HomeComponent,
    FooterComponent,
    StepperComponent,
    AddhostComponent,
    SteppercomComponent,
    AddcommercantComponent,
    UsersDashbaordComponent,
    AddclientComponent,
    LoginUsersComponent,
    StepperexpComponent,
    AddExperienceComponent,
    AddPhotosExpComponent,
    AddActivityComponent,
    AddDishComponent,
    AddTransportComponent,
    AddLodgingComponent,
    AddFoodComponent,
    AddDishPhotosComponent,
    AddLodgingPhotosComponent,
    AddRestaurantPhotosComponent,
    AddTransportPhotosComponent,
    AboutClientComponent,
    SettingClientComponent,
    SettingCommercantComponent,
    AboutCommercantComponent,
    ProfilComponent,
    AbouExperienceComponent,
    EditExperienceComponent,
    HomeExperienceComponent,
    AboutHostComponent,
    SettingHostComponent,
    NotFoundComponent,
    AboutFoodComponent,
    AboutLodgingComponent,
    AboutTransportComponent,
    AddTransportexpComponent,
    AddLodgingexpComponent,
    HomeLodgingComponent,
    HomeTransportComponent,
    HomeRestaurantsComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CarouselModule,
    RadioButtonModule,
    KeyFilterModule,
    PasswordModule,
    CascadeSelectModule,
    DividerModule,
    BrowserAnimationsModule,
    DropdownModule,
    AutoCompleteModule,
    InputTextareaModule,
    InputNumberModule,
    DialogModule,
    ButtonModule,
    CalendarModule,
    InputMaskModule,
		MessageModule,
    MultiSelectModule,
    RatingModule,
    AppRoutingModule
  ],
  providers: [
    //  { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
    /* {
    provide: HTTP_INTERCEPTORS,
    useClass: JwtInterceptorService,
  }*/
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent],
})
export class AppModule {}
