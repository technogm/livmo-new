import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeLodgingComponent } from './home-lodging.component';

describe('HomeLodgingComponent', () => {
  let component: HomeLodgingComponent;
  let fixture: ComponentFixture<HomeLodgingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeLodgingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeLodgingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
