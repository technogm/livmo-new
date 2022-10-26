import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutLodgingComponent } from './about-lodging.component';

describe('AboutLodgingComponent', () => {
  let component: AboutLodgingComponent;
  let fixture: ComponentFixture<AboutLodgingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AboutLodgingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AboutLodgingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
