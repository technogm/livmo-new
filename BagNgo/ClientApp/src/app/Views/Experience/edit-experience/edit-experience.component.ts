import { Component, OnInit } from '@angular/core';
import { SelectItem } from 'primeng/api';

interface Season {
  name: string
}
interface DateTp {
  name: string
}



@Component({
  selector: 'app-edit-experience',
  templateUrl: './edit-experience.component.html',
  styleUrls: ['./edit-experience.component.css']
})
export class EditExperienceComponent implements OnInit {
  SelectedSeason: Season;
  SeasonType: Season[];
  datetype:any='intervalldate'
  dateType: DateTp[];
  selectedDate: any
  SelectedDate: DateTp;


  constructor() { }

  ngOnInit(): void {
    this.getSeason()
    this.getDateType()
  }
  getSeason() {
    this.SeasonType = [
      { name: 'Summer' },
      { name: 'Winter' },
      { name: 'Spring' },
      { name: 'Autumn' },
    ];
  }
  getDateType() {
    this.dateType = [
      { name: 'Interval Date' },
      { name: 'Specific Date' },
      { name: 'Open Date' },
    ];
  }

}
