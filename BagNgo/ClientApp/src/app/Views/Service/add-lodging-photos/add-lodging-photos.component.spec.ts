import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLodgingPhotosComponent } from './add-lodging-photos.component';

describe('AddLodgingPhotosComponent', () => {
  let component: AddLodgingPhotosComponent;
  let fixture: ComponentFixture<AddLodgingPhotosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddLodgingPhotosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLodgingPhotosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
