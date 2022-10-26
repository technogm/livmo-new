import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutCommercantComponent } from './about-commercant.component';

describe('AboutCommercantComponent', () => {
  let component: AboutCommercantComponent;
  let fixture: ComponentFixture<AboutCommercantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AboutCommercantComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AboutCommercantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
