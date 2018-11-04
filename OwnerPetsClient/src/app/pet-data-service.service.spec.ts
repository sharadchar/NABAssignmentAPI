import { TestBed } from '@angular/core/testing';

import { PetDataServiceService } from './pet-data-service.service';

describe('PetDataServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PetDataServiceService = TestBed.get(PetDataServiceService);
    expect(service).toBeTruthy();
  });
});
