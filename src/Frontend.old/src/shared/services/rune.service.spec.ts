import { getLocaleCurrencyName } from '@angular/common';
import { TestBed } from '@angular/core/testing';

import { RuneService } from './rune.service';

describe('RuneService', () => {
  let service: RuneService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RuneService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});