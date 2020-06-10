/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MenuZamowComponent } from './menu-zamow.component';

describe('MenuZamowComponent', () => {
  let component: MenuZamowComponent;
  let fixture: ComponentFixture<MenuZamowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuZamowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuZamowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
