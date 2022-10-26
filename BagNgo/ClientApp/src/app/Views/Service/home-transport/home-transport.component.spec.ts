import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeTransportComponent } from './home-transport.component';

describe('HomeTransportComponent', () => {
  let component: HomeTransportComponent;
  let fixture: ComponentFixture<HomeTransportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeTransportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeTransportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
