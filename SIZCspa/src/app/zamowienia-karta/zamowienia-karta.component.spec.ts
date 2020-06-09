/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ZamowieniaKartaComponent } from './zamowienia-karta.component';

describe('ZamowieniaKartaComponent', () => {
  let component: ZamowieniaKartaComponent;
  let fixture: ComponentFixture<ZamowieniaKartaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ZamowieniaKartaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ZamowieniaKartaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
