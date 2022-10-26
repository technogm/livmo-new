import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTransportPhotosComponent } from './add-transport-photos.component';

describe('AddTransportPhotosComponent', () => {
  let component: AddTransportPhotosComponent;
  let fixture: ComponentFixture<AddTransportPhotosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddTransportPhotosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTransportPhotosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
