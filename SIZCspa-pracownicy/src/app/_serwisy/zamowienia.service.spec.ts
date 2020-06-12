/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ZamowieniaService } from './zamowienia.service';

describe('Service: Zamowienia', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ZamowieniaService]
    });
  });

  it('should ...', inject([ZamowieniaService], (service: ZamowieniaService) => {
    expect(service).toBeTruthy();
  }));
});
