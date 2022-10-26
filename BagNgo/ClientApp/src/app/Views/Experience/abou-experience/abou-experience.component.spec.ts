import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AbouExperienceComponent } from './abou-experience.component';

describe('AbouExperienceComponent', () => {
  let component: AbouExperienceComponent;
  let fixture: ComponentFixture<AbouExperienceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AbouExperienceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AbouExperienceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
