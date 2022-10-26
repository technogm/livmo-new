import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-stepper',
  templateUrl: './stepper.component.html',
  styleUrls: ['./stepper.component.css']
})
export class StepperComponent implements OnInit {

  @Input('activeColor') activeColor = '#F02F32';
  @Input('defaultBackground') defaultBackground = 'bg-black';
  @Input('defaultForeGround') defaultForeGround = 'text-white';
  @Input('length')length = 4;
  @Input('current')current = 1;
  @Input('labels')labels ;
  constructor() { }
  array :any =[]
  ngOnInit(): void {
  }
  getArray(){
    return Array.apply(null, {length: this.length}).map(Number.call, Number).map(n=>n+1)
  }

}
