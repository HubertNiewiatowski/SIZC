/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { KlienciService } from './klienci.service';

describe('Service: Klienci', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [KlienciService]
    });
  });

  it('should ...', inject([KlienciService], (service: KlienciService) => {
    expect(service).toBeTruthy();
  }));
});
