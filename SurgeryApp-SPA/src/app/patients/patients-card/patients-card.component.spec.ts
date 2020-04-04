/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PatientsCardComponent } from './patients-card.component';

describe('PatientsCardComponent', () => {
  let component: PatientsCardComponent;
  let fixture: ComponentFixture<PatientsCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PatientsCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientsCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
