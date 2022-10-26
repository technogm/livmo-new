import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SettingCommercantComponent } from './setting-commercant.component';

describe('SettingCommercantComponent', () => {
  let component: SettingCommercantComponent;
  let fixture: ComponentFixture<SettingCommercantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SettingCommercantComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SettingCommercantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
