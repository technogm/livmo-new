import { TestBed } from '@angular/core/testing';

import { CommercantGuard } from './commercant.guard';

describe('CommercantGuard', () => {
  let guard: CommercantGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(CommercantGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
