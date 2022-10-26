import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutHostComponent } from './about-host.component';

describe('AboutHostComponent', () => {
  let component: AboutHostComponent;
  let fixture: ComponentFixture<AboutHostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AboutHostComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AboutHostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
