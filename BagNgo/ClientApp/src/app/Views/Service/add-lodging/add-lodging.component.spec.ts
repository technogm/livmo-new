import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLodgingComponent } from './add-lodging.component';

describe('AddLodgingComponent', () => {
  let component: AddLodgingComponent;
  let fixture: ComponentFixture<AddLodgingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddLodgingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLodgingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
