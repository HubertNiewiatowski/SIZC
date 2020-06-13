/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ZamowienieEdytujComponent } from './zamowienie-edytuj.component';

describe('ZamowienieEdytujComponent', () => {
  let component: ZamowienieEdytujComponent;
  let fixture: ComponentFixture<ZamowienieEdytujComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ZamowienieEdytujComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ZamowienieEdytujComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
