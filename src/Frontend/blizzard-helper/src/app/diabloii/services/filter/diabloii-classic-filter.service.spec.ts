import { TestBed } from '@angular/core/testing';

import { DiabloiiClassicFilterService } from './diabloii-classic-filter.service';

describe('DiabloiiClassicFilterService', () => {
  let service: DiabloiiClassicFilterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DiabloiiClassicFilterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
