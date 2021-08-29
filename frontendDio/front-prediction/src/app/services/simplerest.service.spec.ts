import { TestBed } from '@angular/core/testing';

import { SimpleRestService } from './simplerest.service';

describe('SimpleRestService', () => {
  let service: SimpleRestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SimpleRestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
