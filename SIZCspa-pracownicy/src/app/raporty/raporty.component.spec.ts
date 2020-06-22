/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RaportyComponent } from './raporty.component';

describe('RaportyComponent', () => {
  let component: RaportyComponent;
  let fixture: ComponentFixture<RaportyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RaportyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RaportyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
