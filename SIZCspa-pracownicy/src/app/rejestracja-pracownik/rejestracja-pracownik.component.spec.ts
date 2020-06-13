/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RejestracjaPracownikComponent } from './rejestracja-pracownik.component';

describe('RejestracjaPracownikComponent', () => {
  let component: RejestracjaPracownikComponent;
  let fixture: ComponentFixture<RejestracjaPracownikComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RejestracjaPracownikComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RejestracjaPracownikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
