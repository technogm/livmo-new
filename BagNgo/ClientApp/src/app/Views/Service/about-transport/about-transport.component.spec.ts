import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutTransportComponent } from './about-transport.component';

describe('AboutTransportComponent', () => {
  let component: AboutTransportComponent;
  let fixture: ComponentFixture<AboutTransportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AboutTransportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AboutTransportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
