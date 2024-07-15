import { TestBed } from '@angular/core/testing';

import { TodoUIService } from './todo-ui.service';

describe('TodoUIService', () => {
  let service: TodoUIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TodoUIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
