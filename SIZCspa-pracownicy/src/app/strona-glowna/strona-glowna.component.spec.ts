/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { StronaGlownaComponent } from './strona-glowna.component';

describe('StronaGlownaComponent', () => {
  let component: StronaGlownaComponent;
  let fixture: ComponentFixture<StronaGlownaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StronaGlownaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StronaGlownaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
