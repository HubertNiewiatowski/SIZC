/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ZamowieniaComponent } from './zamowienia.component';

describe('ZamowieniaComponent', () => {
  let component: ZamowieniaComponent;
  let fixture: ComponentFixture<ZamowieniaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ZamowieniaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ZamowieniaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
