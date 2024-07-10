import { Injectable, WritableSignal, computed, signal } from '@angular/core';
import { TodoState } from '../models/todoState';

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  constructor() { }

  todos: TodoState[] = [
    { id: 1, title: $localize`:title text (meaning)| text to demonstrate translation in code (description):Sweeping floor`, done: false, due: new Date(2024, 6, 15, 21, 45) },
    { id: 2, title: "Leetcode", done: true, due: new Date(2024, 7, 1, 23, 59) },
    { id: 3, title: "Play with cats", done: false, due: new Date(2024, 5, 23) },
  ];
  maxTodoId = () => {
    return this.todos.length > 0 ?
        this.todos
        .map(x => x.id)
        .reduce((prev, curr) => Math.max(prev, curr)) + 1
      : 1;
  };
  get(id: number) {
    return this.todos.find(x => x.id === id);
  }
  getAll() { return this.todos; }
  add(title: string, due: Date) {
    let temp = this.todos.push(
      {
        id: this.maxTodoId(),
        done: false,
        title: title,
        due: due,
      }
    );
  }
  count() {
    return this.todos.length;
  }
  delete(id: number) {
    this.todos = this.todos.filter(x => x.id !== id);
  }
  update(state: TodoState) {
      let todo = this.get(state.id);
      if (todo != null) {
          todo.title = state.title;
          todo.due = state.due;
      }
  }
  updateDone(id: number) {
    let targetState = this.get(id);
    if (targetState) {
        targetState.done = !targetState?.done
    }
  }
}
