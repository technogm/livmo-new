import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRestaurantPhotosComponent } from './add-restaurant-photos.component';

describe('AddRestaurantPhotosComponent', () => {
  let component: AddRestaurantPhotosComponent;
  let fixture: ComponentFixture<AddRestaurantPhotosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddRestaurantPhotosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddRestaurantPhotosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
