import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TodoInputGroup } from './input-group.component';

describe('InputGroupComponent', () => {
  let component: TodoInputGroup;
  let fixture: ComponentFixture<TodoInputGroup>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TodoInputGroup]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TodoInputGroup);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
