import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDishPhotosComponent } from './add-dish-photos.component';

describe('AddDishPhotosComponent', () => {
  let component: AddDishPhotosComponent;
  let fixture: ComponentFixture<AddDishPhotosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDishPhotosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDishPhotosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
