import { TestBed } from '@angular/core/testing';

import { DiabloiiClassisRuneService } from './diabloii-classis-rune.service';

describe('DiabloiiClassisRuneService', () => {
  let service: DiabloiiClassisRuneService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DiabloiiClassisRuneService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
