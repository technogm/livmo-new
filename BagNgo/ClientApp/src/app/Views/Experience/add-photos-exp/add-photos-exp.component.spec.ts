import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPhotosExpComponent } from './add-photos-exp.component';

describe('AddPhotosExpComponent', () => {
  let component: AddPhotosExpComponent;
  let fixture: ComponentFixture<AddPhotosExpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPhotosExpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPhotosExpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
