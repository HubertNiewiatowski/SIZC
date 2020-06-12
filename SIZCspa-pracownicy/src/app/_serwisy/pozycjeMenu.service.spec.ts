/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PozycjeMenuService } from './pozycjeMenu.service';

describe('Service: PozycjeMenu', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PozycjeMenuService]
    });
  });

  it('should ...', inject([PozycjeMenuService], (service: PozycjeMenuService) => {
    expect(service).toBeTruthy();
  }));
});
