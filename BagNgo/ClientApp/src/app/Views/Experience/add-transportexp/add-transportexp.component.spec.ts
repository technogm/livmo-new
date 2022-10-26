import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTransportexpComponent } from './add-transportexp.component';

describe('AddTransportexpComponent', () => {
  let component: AddTransportexpComponent;
  let fixture: ComponentFixture<AddTransportexpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddTransportexpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTransportexpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
