/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PracownikKartaComponent } from './pracownik-karta.component';

describe('PracownikKartaComponent', () => {
  let component: PracownikKartaComponent;
  let fixture: ComponentFixture<PracownikKartaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PracownikKartaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PracownikKartaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
