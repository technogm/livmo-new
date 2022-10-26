import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StepperexpComponent } from './stepperexp.component';

describe('StepperexpComponent', () => {
  let component: StepperexpComponent;
  let fixture: ComponentFixture<StepperexpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StepperexpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StepperexpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
