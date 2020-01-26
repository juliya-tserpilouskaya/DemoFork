import { TestBed } from '@angular/core/testing';

import { HttpcourseService } from './httpcourse.service';

describe('HttpcourseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HttpcourseService = TestBed.get(HttpcourseService);
    expect(service).toBeTruthy();
  });
});
