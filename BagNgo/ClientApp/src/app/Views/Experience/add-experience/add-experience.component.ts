import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { forkJoin, from } from 'rxjs';
import { AuthService } from 'src/app/Services/Auth.service';
import { ExperienceService } from 'src/app/Services/experience.service';
import { HttpService } from 'src/app/Services/Http/http.service';
import { SelectItem } from 'primeng/api';

interface DateTp {
  name: string
}
interface Season {
  name: string
}
interface Theme {
  name: string
}
interface SubTheme {
  name: string
}
interface price {
  name: string
}

interface daysOff {
  name: string
}




@Component({
  selector: 'app-add-experience',
  templateUrl: './add-experience.component.html',
  styleUrls: ['./add-experience.component.css']
})

export class AddExperienceComponent implements OnInit {
  labels = ['Your Idea', 'Essential Information', 'Activity Page', 'Servies', 'Participation Terms']
  isselected = "individual"
  step = 1
  startD: Date;
  startT: Date;
  endD: Date;
  endT: Date;
  startDA: Date;
  startTA: Date;
  endDA: Date;
  endTA: Date;
  startLodg: Date;
  endLodg: Date;

  startTR: Date;
  endDR: Date;
  startDR: Date;
  endTR: Date;

  endtime: Date;
  expPictures = []
  steplength = 5;
  value15: number;
  spotsValue: number = 1;
  displayBasic: boolean;
  displayActivity: boolean;
  displayFood: boolean;
  displayLodging: boolean;
  displayTransport: boolean;
  autoResize: boolean = true;
  activities = []
  Lodgings = []
  Foods = []
  Transports = []
  SelectedDate: DateTp;
  dateType: DateTp[];
  SelectedSeason: Season;
  SeasonType: Season[];
  selectedDate: any;
  ConfirmModal : boolean = false;
  selectDay: daysOff;
  ListDays: daysOff[];
  Price: price;
  PriceList: Season[];

  SelectedTheme: Theme;
  ThemeType: Theme[];
  SelectedSub: SubTheme;
  SubType: SubTheme[];

  DateArray = [];
  Form1Experience: FormGroup
  Form2Experience: FormGroup
  Validation: FormGroup
  Form5Experience: FormGroup
  AddActivity: FormGroup
  AddFood: FormGroup
  AddLodging: FormGroup
  AddTransport: FormGroup

  TimeIntervall: FormGroup
  TimeOpen: FormGroup
  TimeSpecific: FormGroup

  ActImages = []
  FoodImages = []
  LodgingImages = []
  TransportImages = []

  constructor(private fb: FormBuilder, private http: HttpService,
    private route: Router,
    private experienceService: ExperienceService) {
  }


  ngOnInit() {
    this.SetupFormControl()
    this.getDateType()
    this.getSeason()
    console.log(this.ActImages.values())
    this.getPriceList();
    this.getDaysOff();
    this.getThemes();
    this.getSubThemes();


  }

  getThemes() {
    this.ThemeType = [
      { name: 'Nature' },
      { name: 'Health' },
      { name: 'Food' },
      { name: 'Event' },
      { name: 'Culture' },
      { name: 'SeaSide' },
    ];
  }

  getSubThemes() {
    this.SubType = [
      { name: 'JetSki' },
      { name: 'Shopping' },
      { name: 'Gambling' },
      { name: 'Yoga' },
      { name: 'Sport' },
      { name: 'Fishing' },
      { name: 'Hunt' },
    ];
  }

  getDaysOff() {
    this.ListDays = [
      { name: 'Monday' },
      { name: 'Tuesday' },
      { name: 'Wednesday' },
      { name: 'Thursday' },
      { name: 'Friday' },
      { name: 'Saturday' },
      { name: 'Sunday' },
    ];
  }

  getPriceList() {
    this.PriceList = [
      { name: 'Person' },
      { name: 'Hour' },
      { name: 'Day' },
      { name: 'Night' },
      { name: 'Session' },
    ];
  }
  clickFakeUpload(id: any) {
    document.getElementById(id).click()
  }
  uploadedFile(e, id) {
    if (e.target.files && e.target.files[0]) {
      const file = e.target.files[0];
      const reader = new FileReader();
      reader.onload = e => {
        let data: any = reader.result
        if (file.type.indexOf('video') != -1) {
        }
        else if (file.type.indexOf('image') != -1) {
          if (id == 'Image') {
            this.ActImages.push({ data, file })
          }
          else if (id == "ImageFood") {
            this.FoodImages.push({ data, file })
          }
          else if (id == "ImageTransport") {
            this.TransportImages.push({ data, file })
          }
          else if (id == "ImageLodging") {
            this.LodgingImages.push({ data, file })
          }
        }
      };
      reader.readAsDataURL(file);
    }
  }
  deleteImg(index) {
    this.ActImages.splice(index, 1)
  }
  deleteFoodImg(index) {
    this.FoodImages.splice(index, 1)
  }
  deleteTransportImg(index) {
    this.TransportImages.splice(index, 1)
  }
  deleteLodgingImg(index) {
    this.LodgingImages.splice(index, 1)
  }
  getDateType() {
    this.dateType = [
      { name: 'Interval Date' },
      { name: 'Specific Date' },
      { name: 'Open Date' },
    ];
  }
  getSeason() {
    this.SeasonType = [
      { name: 'Summer' },
      { name: 'Winter' },
      { name: 'Spring' },
      { name: 'Autumn' },
    ];
  }
  getlabels() {
    switch (this.isselected) {
      case 'individual':
        return ['Your Idea', 'Essential Information', 'Activity Page', 'Servies', 'Participation Terms']
      case 'organisation':
        return ['Your Idea', 'Essential Information', 'Activity Page', 'Servies', 'Participation Terms']
      default:
        break;
    }
  }
  SetupFormControl() {
    this.AddActivity = this.fb.group({
      "title": ['', Validators.required],
      "description": ['', Validators.required],
      "startTimeActivity": new Date(),
      "endDateActivity": new Date(),
      "endTimeActivity": new Date(),
      "startDateActivity": new Date(),
    })
    this.Validation = this.fb.group({
      foodExist: false,
      transportExist: false,
      lodgingExist: false,
    })
    this.AddFood = this.fb.group({
      "nameDish": ['', Validators.required],
      "description": [null, Validators.required],
    })
    this.AddLodging = this.fb.group({
      "category": ['', Validators.required],
      "type": ['', Validators.required],
      "adress": ['', Validators.required],
      "description": ['', Validators.required],
      "instructions": ['', Validators.required],
      "criteria": ['', Validators.required],
      "startDateLodgignExp": [new Date(), Validators.required],
      "endDateLodgingExp": [new Date(), Validators.required],

    })
    this.AddTransport = this.fb.group({

      "vehiculeName": ['', Validators.required],
      "seats": 0,
      "toGoFrom": ["", Validators.required],
      "toGoFromDeparture": new Date(),
      "toGoTo": ["", Validators.required],
      "toGoToArrival": new Date(),
      "toReturnFrom": ["", Validators.required],
      "toReturnFromDeparture": new Date(),
      "toReturnTo": ["", Validators.required],
      "toReturnToArrival": new Date(),
      "description": ["", Validators.required],

    })
    this.Form1Experience = this.fb.group({
      "experienceTitle": ['', Validators.required],
      "theme": ['', Validators.required],
      "location": ['', Validators.required],
      "price": ['', Validators.required],
      "priceUnit": ['', Validators.required],
      "spots": ['', Validators.required],
      "mapLocation": ['', Validators.required],
      "subTheme": ['', Validators.required],

    })
    this.TimeIntervall = this.fb.group({
      "endTimeExpDate": new Date(),
      "startTimeExpDate": new Date(),

    })

    this.TimeOpen = this.fb.group({
      "durationDays": 0,
      "durationHours": 0,

    })

    this.TimeSpecific = this.fb.group({
      "startTime": new Date(),
      "endTime": new Date(),
      "startDate": new Date(),
      "endDate": new Date(),
    })

    this.Form2Experience = this.fb.group({
      "datType": ['', Validators.required],
      "season": ['', Validators.required],
      "experienceDescription": ['', Validators.required],
      "daysOff": "",

    })
    this.Form5Experience = this.fb.group({
      "minAge": ['', Validators.required],
      "petsAllowed": [false, Validators.required],
      "otherCritics": ['', Validators.required],

    })

  }
  Update() {
    // if isselected = interval => open w lokhra null 
  }


  switchCase: boolean = false;
  toggleButton() {
    this.switchCase = !this.switchCase;
  }
  switchCase2: boolean = false;
  toggleButton2() {
    this.switchCase2 = !this.switchCase2;
  }
  switchCase3: boolean = false;
  toggleButton3() {
    this.switchCase3 = !this.switchCase3;
  }
  showBasicDialog2() {
    this.displayBasic = true;
  }
  showActivity() {
    this.displayActivity = true;
  }
  showFood() {
    this.displayFood = true;
  }

  showTransport() {
    this.displayTransport = true;
  }

  showLodging() {
    this.displayLodging = true;
  }

  HideActiv() {
    this.displayActivity = false;
    this.AddActivity = this.fb.group({
      "title": "",
      "description": "",
      "endDate": "",
      "startDate": "",
      "endTime": "",
      "startTime": "",
    })
    this.ActImages = []
  }
  HideLodging() {
    this.displayLodging = false;
    this.AddLodging = this.fb.group({
      "category": "",
      "type": "",
      "adress": "",
      "description": "",
      "instructions": "",
      "criteria": "",
      "startDateLodgignExp": "",
      "endDateLodgingExp": "",

    })
    this.LodgingImages = []
  }
  HideTransport() {
    this.displayTransport = false;
    this.AddTransport = this.fb.group({
      "vehiculeName": "",
      "seats": "",
      "toGoFrom": "",
      "toGoFromDeparture": "",
      "toGoTo": "",
      "toGoToArrival": "",
      "toReturnFrom": "",
      "toReturnFromDeparture": "",
      "toReturnTo": "",
      "toReturnToArrival": "",
      "description": "",
    })
    this.TransportImages = []
  }
  HideFood() {
    this.displayFood = false;
    this.AddFood = this.fb.group({
      "nameDish": "",
      "description": "",
    })
    this.FoodImages = []
  }

  addActivity() {
    this.activities.push(this.AddActivity.value)
    this.activities[this.activities.length - 1].ActImages = [...this.ActImages]
    this.ActImages = []
    console.log(this.AddActivity)
    this.AddActivity = this.fb.group({
      "title": ['', Validators.required],
      "description": [null, Validators.required],
      "endDateActivity": new Date(),
      "startDateActivity": new Date(),
      "endTimeActivity": new Date(),
      "startTimeActivity": new Date(),

    })
    this.displayActivity = false
  }
  addLodging() {
    this.Lodgings.push(this.AddLodging.value)
    this.Lodgings[this.Lodgings.length - 1].LodgingImages = [...this.LodgingImages]
    this.LodgingImages = []
    console.log(this.AddLodging)
    this.AddLodging = this.fb.group({
      "category": ['', Validators.required],
      "type": ['', Validators.required],
      "adress": ['', Validators.required],
      "description": ['', Validators.required],
      "instructions": ['', Validators.required],
      "criteria": ['', Validators.required],
      "startDateLodgignExp": [new Date(), Validators.required],
      "endDateLodgingExp": [new Date(), Validators.required],

    })
    this.displayLodging = false
  }
  addTransport() {
    this.Transports.push(this.AddTransport.value)
    this.Transports[this.Transports.length - 1].TransportImages = [...this.TransportImages]
    this.TransportImages = []
    console.log(this.AddTransport)
    this.AddTransport = this.fb.group({

      "vehiculeName": ['', Validators.required],
      "seats": 0,
      "toGoFrom": ["", Validators.required],
      "toGoFromDeparture": [new Date(), Validators.required],
      "toGoTo": ["", Validators.required],
      "toGoToArrival": [new Date(), Validators.required],
      "toReturnFrom": ["", Validators.required],
      "toReturnFromDeparture": [new Date(), Validators.required],
      "toReturnTo": ["", Validators.required],
      "toReturnToArrival": [new Date(), Validators.required],
      "description": ["", Validators.required],


    })
    this.displayTransport = false
  }
  addFood() {
    this.Foods.push(this.AddFood.value)
    this.Foods[this.Foods.length - 1].FoodImages = [...this.FoodImages]
    this.FoodImages = []
    console.log(this.FoodImages)
    this.AddFood = this.fb.group({
      "nameDish": ['', Validators.required],
      "description": [null, Validators.required],

    })
    this.displayFood = false
  }
  addDat() {
    this.DateArray.push({ start: this.input1, end: this.input2 });
    this.input1 = new Date()
    this.input2 = new Date()
  }
  deleteActivity(activity) {
    this.activities = this.activities.filter(e => e.title !== activity.title)
  }
  deleteFood(food) {
    this.Foods = this.Foods.filter(e => e.nameDish !== food.nameDish)
  }
  deleteLodging(lodging) {
    this.Lodgings = this.Lodgings.filter(e => e.category !== lodging.category)
  }
  deleteTransport(transport) {
    this.Transports = this.Transports.filter(e => e.vehiculeName !== transport.vehiculeName)
  }
  deleteTime(index) {
    this.DateArray.splice(index, 1)
  }
  //input1: any = ''
  //input2: any = ''
  input1 = new Date();
  input2 = new Date();

  AddFullExperience() {

    var data = {
      ...this.Form1Experience.value, ...this.Form2Experience.value, ...this.Form5Experience.value, ...this.AddActivity.value, ...this.AddLodging.value,
      ...this.AddTransport.value, ...this.AddFood.value, ...this.TimeIntervall.value, ...this.TimeSpecific.value, ...this.TimeOpen.value, ...this.Validation.value
    }
    console.log(this.Form1Experience.value.experienceTitle);
    data.theme = this.Form1Experience.value.theme.name;
    data.subTheme = this.Form1Experience.value.subTheme.name;
    data.season = this.SelectedSeason.name;
    data.datType = this.Form2Experience.value.datType.name;
    console.log(data);

    this.experienceService.SaveExperience(localStorage.getItem('ID'), {...data, daysOff : JSON.stringify(this.daysOff.value)}).subscribe({
      next: (exp: any) => {
        const expImageArray = []
        this.activities.forEach(async activity => {
          const savedActiv: any = await this.experienceService.SaveActivity(exp.experienceId, {
            Title: activity.title, Description: activity.description, StartDateActivity: activity.startDateActivity
            , EndDateActivity: activity.endDateActivity, EndTimeActivity: activity.endTimeActivity, StartTimeActivity: activity.startTimeActivity
          }).toPromise()
          if (activity.ActImages == undefined) activity.ActImages = []
          activity.ActImages.forEach(async d => {
            await this.experienceService.SaveActivityImg(savedActiv.activiteId, d.file).toPromise()
          })
        })
        this.DateArray.forEach(async date => {
          const savedates: any = await this.experienceService.SaveExperienceDates(exp.experienceId, {
            StartTimeExpDate: date.startTimeExpDate, EndTimeExpDate: date.endTimeExpDate
          }).toPromise()
        })
        // Lodging :
        if (this.lodgingExist.value == true) {
          this.Lodgings.forEach(async lodging => {
            const savedLodg: any = await this.experienceService.SaveLodgigngs(exp.experienceId, {
              Category: lodging.category, Type: lodging.type, Adress : lodging.adress,
              Description: lodging.description, Instructions: lodging.instructions, Criteria: lodging.criteria,
              StartDateLodgignExp: lodging.startDateLodgignExp, EndDateLodgingExp: lodging.endDateLodgingExp
            }).toPromise()
            if (lodging.LodgingImages == undefined) lodging.LodgingImages = []
            lodging.LodgingImages.forEach(async d => {
              await this.experienceService.SaveLodgingsImg(savedLodg.lodgingId, d.file).toPromise()
            })
          })
        }
        // Food 
        if (this.foodExist.value == true) {
          this.Foods.forEach(async food => {
            const savedFood: any = await this.experienceService.SaveFood(exp.experienceId, { NameDish: food.nameDish, Description: food.description, }).toPromise()
            if (food.FoodImages == undefined) food.FoodImages = []
            food.FoodImages.forEach(async d => {
              await this.experienceService.SaveFoodImg(savedFood.foodId, d.file).toPromise()
            })
          })
        }
        // Transport

        if (this.tranpsortExist.value == true) {
          this.Transports.forEach(async trans => {
            const savedtrans: any = await this.experienceService.SaveTransport(exp.experienceId, {
              VehiculeName: trans.vehiculeName, Seats: trans.seats,
              ToGoFrom: trans.toGoFrom, ToGoFromDeparture: trans.toGoFromDeparture, ToGoTo: trans.toGoTo, ToGoToArrival: trans.toGoToArrival, ToReturnFrom: trans.toReturnFrom,
              ToReturnFromDeparture: trans.toReturnFromDeparture, ToReturnTo: trans.toReturnTo, ToReturnToArrival: trans.toReturnToArrival, Description: trans.description
            }).toPromise()
            if (trans.TransportImages == undefined) trans.TransportImages = []
            trans.TransportImages.forEach(async d => {
              await this.experienceService.SaveTransportImg(savedtrans.transportId, d.file).toPromise()
            })
          })
        }
        console.log(exp.experienceId);
        this.expPictures.forEach(img => {
          expImageArray.push(this.experienceService.SaveExpImg(exp.experienceId, img.file))
        })
        forkJoin(expImageArray).subscribe()
        this.ConfirmModal = true;
      },
      error: () => {
      }
    })
  }

  get lodgingExist() { return this.Validation.get('lodgingExist'); }
  get foodExist() { return this.Validation.get('foodExist'); }
  get tranpsortExist() { return this.Validation.get('transportExist'); }

  get startTimeExpDate() { return this.TimeIntervall.get('startTimeExpDate'); }
  get endTimeExpDate() { return this.TimeIntervall.get('endTimeExpDate'); }

  get durationDays() { return this.TimeOpen.get('durationDays'); }
  get durationHours() { return this.TimeOpen.get('durationHours'); }


  get vehiculename() { return this.AddTransport.get('vehiculeName'); }
  get seats() { return this.AddTransport.get('seats'); }
  get toGoFrom() { return this.AddTransport.get('toGoFrom'); }
  get toGoFromDeparture() { return this.AddTransport.get('toGoFromDeparture'); }
  get toGoTo() { return this.AddTransport.get('toGoTo'); }
  get toGoToArrival() { return this.AddTransport.get('toGoToArrival'); }
  get toReturnFrom() { return this.AddTransport.get('toReturnFrom'); }
  get toReturnFromDeparture() { return this.AddTransport.get('toReturnFromDeparture'); }
  get toReturnTo() { return this.AddTransport.get('toReturnTo'); }
  get toReturnToArrival() { return this.AddTransport.get('toReturnToArrival'); }
  get descriptiontr() { return this.AddTransport.get('description'); }


  get categoryLod() { return this.AddLodging.get('category'); }
  get typeLod() { return this.AddLodging.get('type'); }
  get adressLod() { return this.AddLodging.get('adress'); }
  get descriptionLod() { return this.AddLodging.get('description'); }
  get instructionsLod() { return this.AddLodging.get('instructions'); }
  get criteriaLod() { return this.AddLodging.get('criteria'); }
  get startDateLodgingExp() { return this.AddLodging.get('startDateLodgingExp'); }
  get endDateLodgingExp() { return this.AddLodging.get('endDateLodgingExp'); }


  get NameDish() { return this.AddFood.get('nameDish'); }
  get descriptipnFood() { return this.AddFood.get('description'); }

  get titleAct() { return this.AddActivity.get('title'); }
  get startDateActivity() { return this.AddActivity.get('startDateActivity'); }
  get startTimeActivity() { return this.AddActivity.get('startTimeActivity'); }
  get endDateActivity() { return this.AddActivity.get('endDateActivity'); }
  get endTimeActivity() { return this.AddActivity.get('endTimeActivity'); }

  get desc() { return this.AddActivity.get('description'); }


  get datType() { return this.Form2Experience.get('datType'); }
  get startTime() { return this.TimeSpecific.get('startTime'); }
  get endTime() { return this.TimeSpecific.get('endTime'); }
  get startDate() { return this.TimeSpecific.get('startDate'); }
  get endDate() { return this.TimeSpecific.get('endDate'); }
  get daysOff() { return this.Form2Experience.get('daysOff'); }
  get season() { return this.Form2Experience.get('season'); }
  get experienceDescription() { return this.Form2Experience.get('experienceDescription'); }


  get minAge() { return this.Form5Experience.get('minAge'); }
  get petsAllowed() { return this.Form5Experience.get('petsAllowed'); }
  get otherCritics() { return this.Form5Experience.get('otherCritics'); }

  get experienceTitle() { return this.Form1Experience.get('experienceTitle'); }
  get theme() { return this.Form1Experience.get('theme'); }
  get location() { return this.Form1Experience.get('location'); }
  get price() { return this.Form1Experience.get('price'); }
  get priceUnit() { return this.Form1Experience.get('priceUnit'); }
  get spots() { return this.Form1Experience.get('spots'); }
  get subTheme() { return this.Form1Experience.get('subTheme'); }
  get mapLocation() { return this.Form1Experience.get('mapLocation'); }


  NextStepValidationActivity() {
    return this.titleAct.valid && this.desc.valid, this.ActImages.length > 2;
  }
}
