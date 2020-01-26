import { TestBed } from '@angular/core/testing';

import { HttpTestClientService } from './http-test-client.service';

describe('HttpTestClientService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HttpTestClientService = TestBed.get(HttpTestClientService);
    expect(service).toBeTruthy();
  });
});
