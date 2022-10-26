import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SteppercomComponent } from './steppercom.component';

describe('SteppercomComponent', () => {
  let component: SteppercomComponent;
  let fixture: ComponentFixture<SteppercomComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SteppercomComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SteppercomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
