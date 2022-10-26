import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLodgingexpComponent } from './add-lodgingexp.component';

describe('AddLodgingexpComponent', () => {
  let component: AddLodgingexpComponent;
  let fixture: ComponentFixture<AddLodgingexpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddLodgingexpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLodgingexpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
