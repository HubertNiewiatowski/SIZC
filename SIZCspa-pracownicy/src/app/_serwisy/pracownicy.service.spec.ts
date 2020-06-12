/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PracownicyService } from './pracownicy.service';

describe('Service: Pracownicy', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PracownicyService]
    });
  });

  it('should ...', inject([PracownicyService], (service: PracownicyService) => {
    expect(service).toBeTruthy();
  }));
});
