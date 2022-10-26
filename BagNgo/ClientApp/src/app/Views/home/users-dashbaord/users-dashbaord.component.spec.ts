import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersDashbaordComponent } from './users-dashbaord.component';

describe('UsersDashbaordComponent', () => {
  let component: UsersDashbaordComponent;
  let fixture: ComponentFixture<UsersDashbaordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsersDashbaordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsersDashbaordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
