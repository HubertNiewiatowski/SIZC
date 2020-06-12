/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AutoryzacjaService } from './autoryzacja.service';

describe('Service: Autoryzacja', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AutoryzacjaService]
    });
  });

  it('should ...', inject([AutoryzacjaService], (service: AutoryzacjaService) => {
    expect(service).toBeTruthy();
  }));
});
