import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SettingHostComponent } from './setting-host.component';

describe('SettingHostComponent', () => {
  let component: SettingHostComponent;
  let fixture: ComponentFixture<SettingHostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SettingHostComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SettingHostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
