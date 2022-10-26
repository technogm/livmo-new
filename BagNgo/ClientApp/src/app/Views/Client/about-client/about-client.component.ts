import { Component, OnInit } from '@angular/core';
import { ClientService } from 'src/app/Services/client.service';
import { ExperienceService } from 'src/app/Services/experience.service';
import { Router, ActivatedRoute } from '@angular/router';
import { HostServiceService } from 'src/app/Services/host.service';
import { ServicesCommercantService } from 'src/app/Services/services-commercant.service';
import { CommercantService } from 'src/app/Services/commercant.service';

@Component({
  selector: 'app-about-client',
  templateUrl: './about-client.component.html',
  styleUrls: ['./about-client.component.css']
})
export class AboutClientComponent implements OnInit {
  isSelected: any = 'his';
  name: any;
  photoLink: any;
  nameH: any;
  photoLinkH: any;
  nameC: any;
  photoLinkC: any;

  dataArray: any;
  experinceV: any;
  lodgingV: any;
  TrabsportV: any;
  FoodV: any;
  host: any;
  experienceName: any;
  DescEXP: any;
  theme: any;
  subTheme: any;
  expPrice: any;
  expPriceUnit: any;
  experienceStart: any;
  locationExp: any;
  experienceEnd: any;
  hostId: any;
  expId: any;
  experienceArray: any;
  lodgingArray: any;
  FoodArray: any;
  TransportArray: any;
  StatusRes: any;
  lodgingame: any;
  commercantid: any;
  lodgAdr: any;
  priceLodg: any;
  webLodg: any;
  lodgType: any;
  lodgCat: any;
  lodgDesc: any;
  commercant: any;
  experiencePhotos: any;

  // Transport :
  activTr: any;
  vehTrname: any;
  gouverTr: any;
  seatsTr: any;
  rulesTr: any;
  priceTr: any;
  typeTr: any;
  nameTr: any;
  photoLinkTr: any;
  commercantTr: any;
  commercantIidTr: any;

  // Food :
  priceF: any;
  RestaurF: any;
  dishN: any;
  dishDesc: any;
  adrF: any;
  nameF: any;
  photoLinkF: any;
  commercantF: any;
  commercantIidF: any;

  //

  id: any = localStorage.getItem("ID");
  role: any = localStorage.getItem("UserRole");
  constructor(private ClientService: ClientService, private experienceService: ExperienceService, private router: Router,
    private activatedRoute: ActivatedRoute, private CommercantService: CommercantService,
    private HostService: HostServiceService, private ServiceService: ServicesCommercantService) {
    this.ClientService.getClientById(this.id).subscribe(data => {
      this.dataArray = data;
      this.name = this.dataArray.nom;
      this.photoLink = this.dataArray.photoLink;

    })
    this.experienceService.getClientExperienceReservation(this.id).subscribe(data => {
      // Les reservations des experiences
      this.experienceArray = data
      console.log("reservation 1", this.experienceArray)
      for (let i = 0; i < this.experienceArray.length; i++) {

        this.experienceService.getExperienceById(this.experienceArray[i].experienceId).subscribe(
          reponse => {
            // les experiences déja reservés !!!
            this.experienceArray[i].details = reponse
            this.experinceV = reponse;
            this.host = this.experinceV.hostId;
            this.theme = this.experinceV.theme;
            this.subTheme = this.experinceV.subTheme;
            this.DescEXP = this.experinceV.experienceDescription;
            this.experienceName = this.experinceV.experienceTitle;
            this.experienceStart = this.experinceV.startDate;
            this.experienceEnd = this.experinceV.endDate;
            this.expPrice = this.experinceV.price;
            this.expPriceUnit = this.experinceV.priceUnit;
            this.locationExp = this.experinceV.location;
            this.expId = this.experinceV.experienceId;

            console.log("Booked experiences", this.experinceV);
            
            this.experienceService.getExperiencePhotosById(this.experienceArray[i].experienceId).subscribe(
              (reponse: any) => {
                console.log(this.experiencePhotos);
                this.experiencePhotos = reponse;
                this.experienceArray[i] = { ...this.experienceArray[i], img: this.experiencePhotos[0] }
    
              })

            this.HostService.getHostById(this.host).subscribe(data => {
            this.experienceArray[i].host = data

              // this.host = data;
              // this.nameH = this.host.legalName;
              // this.photoLinkH = this.host.photoLink;
              // this.hostId = this.host.hostId;

              // console.log(this.nameH);

            })
          })

      }

    });

    this.ServiceService.getClientLodgingReservation(this.id).subscribe(data => {
      // Les reservations des experiences
      this.lodgingArray = data
      console.log("Lodging Reservation 1", this.lodgingArray)
      for (let i = 0; i < this.lodgingArray.length; i++) {

        this.ServiceService.getLodgingById(this.lodgingArray[i].lodgingId).subscribe(
          reponse => {
            // les experiences déja reservés !!!
            this.lodgingArray[i].lodging = reponse
            this.lodgingV = reponse;
            this.commercant = this.lodgingV.commercantId;
            this.lodgingame = this.lodgingV.lodgingName;
            this.lodgAdr = this.lodgingV.lodgingAdress;
            this.priceLodg = this.lodgingV.pricePerNight;
            this.webLodg = this.lodgingV.website;
            this.lodgCat = this.lodgingV.lodgingCategory;
            this.lodgDesc = this.lodgingV.lodgingDescript;
            this.lodgType = this.lodgingV.lodgingType;
            console.log("Booked Lodgings", this.lodgingV);

            

            this.CommercantService.getCommercantById(this.commercant).subscribe(data => {
              this.lodgingArray[i].commLodg = data
             /* this.commercant = data;
              this.nameC = this.commercant.legalName;
              this.photoLinkC = this.commercant.photoLink;
              this.commercantid = this.commercant.commercantId;

              console.log(this.nameC);*/

            })
          })

      }

    });

    this.ServiceService.GetClientTransportReservation(this.id).subscribe(data => {
      // Les reservations des experiences
      this.TransportArray = data
      console.log("Transport Reservation 1", this.TransportArray)
      for (let i = 0; i < this.TransportArray.length; i++) {

        this.ServiceService.getTrasportById(this.TransportArray[i].transportId).subscribe(
          reponse => {
            // les experiences déja reservés !!! 
            this.TransportArray[i].transport = reponse;
            this.TrabsportV = reponse;
            this.commercantTr = this.TrabsportV.commercantId;
            this.activTr = this.TrabsportV.activity;
            this.vehTrname = this.TrabsportV.vehuculeName;
            this.gouverTr = this.TrabsportV.gouvernorate;
            this.seatsTr = this.TrabsportV.numberOfSeatd;
            this.rulesTr = this.TrabsportV.vehiculeRules;
            this.priceTr = this.TrabsportV.pricePerDay;
            this.typeTr = this.TrabsportV.type;
            console.log("Booked Transports", this.TrabsportV);
            this.CommercantService.getCommercantById(this.commercantTr).subscribe(data => {
              this.TransportArray[i].commTr = data

             /* this.commercantTr = data;
              this.nameTr = this.commercantTr.legalName;
              this.photoLinkTr = this.commercantTr.photoLink;
              this.commercantIidTr = this.commercantTr.commercantId;
              console.log(this.nameC);*/
            })
          })
      }
    });
    this.ServiceService.getClientFoodReservation(this.id).subscribe(data => {
      this.FoodArray = data
      console.log("Fodd Reservation 1", this.FoodArray)
      for (let i = 0; i < this.FoodArray.length; i++) {

        this.ServiceService.getFoodById(this.FoodArray[i].foodServId).subscribe(
          reponse => {
            this.FoodArray[i].food = reponse;
            this.FoodV = reponse;
            this.commercantF = this.FoodV.commercantId;
            this.priceF = this.FoodV.foodPrice;
            this.RestaurF = this.FoodV.restaurantName;
            this.dishN = this.FoodV.dishName;
            this.dishDesc = this.FoodV.dishDescription;
            this.adrF = this.FoodV.adress;

            console.log("Booked Foods : ", this.FoodV);

            this.CommercantService.getCommercantById(this.commercantF).subscribe(data => {
              this.FoodArray[i].commF = data
              this.commercantF = data;
              this.nameF = this.commercantF.legalName;
              this.photoLinkF = this.commercantF.photoLink;
              this.commercantIidF = this.commercantF.commercantId;

              console.log("Food Commercant",this.nameF);

            })
          })
      }
    });


  }
  ngOnInit(): void {
  }

  async DeleteExperienceReservation(expID: any) {
    await this.ServiceService.DeleteExperienceRes(expID).subscribe(response => {
      console.log(response)
      window.location.reload();
    })
  }
  async DeleteFoodReservation(expID: any) {
    await this.ServiceService.DeleteFoodRes(expID).subscribe(response => {
      console.log(response)
      //window.location.reload();
      this.ngOnInit();

    })
  }
  async DeleteTransReservation(expID: any) {
    await this.ServiceService.DeleteTransportRes(expID).subscribe(response => {
      console.log(response)
      window.location.reload();
    })
  }
  async DeleteLodgReservation(expID: any) {
    await this.ServiceService.DeleteLodgingRes(expID).subscribe(response => {
      console.log(response)
      window.location.reload();
    })
  }
  goToDetails(a: any) {
    this.router.navigate(['aboutExperience', a]);
  }
  goToFoodDetails(a: any) {
    this.router.navigate(['aboutFood', a]);
  }
  goToTransportDetails(a: any) {
    this.router.navigate(['aboutTransport', a]);
  }
  goToLodgingDetails(a: any) {
    this.router.navigate(['aboutLodging', a]);
  }
  goToProfil(a: any) {
    this.router.navigate(['Profil', a]);
  }
  OpenH(): void {
    this.isSelected = 'his';
    console.log(this.isSelected);

  }
  OpenR(): void {
    this.isSelected = 'res';
    console.log(this.isSelected);

  }
  OpenF(): void {
    this.isSelected = 'fav';
    console.log(this.isSelected);

  }
  OpenP(): void {
    this.isSelected = 'pro';
    console.log(this.isSelected);

  }
  OpenM(): void {
    this.isSelected = 'msg';
    console.log(this.isSelected);

  }

}
