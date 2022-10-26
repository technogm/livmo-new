import { Component,Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-stepperexp',
  templateUrl: './stepperexp.component.html',
  styleUrls: ['./stepperexp.component.css']
})
export class StepperexpComponent implements OnInit {
  @Input('activeColor') activeColor = '#F02F32';
  @Input('defaultBackground') defaultBackground = 'bg-white';
  @Input('defaultForeGround') defaultForeGround = 'text-black';
  @Input('length')length = 5;
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