/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PracownikEdytujComponent } from './pracownik-edytuj.component';

describe('PracownikEdytujComponent', () => {
  let component: PracownikEdytujComponent;
  let fixture: ComponentFixture<PracownikEdytujComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PracownikEdytujComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PracownikEdytujComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
