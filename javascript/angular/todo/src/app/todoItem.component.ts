import { Component, Input, Output, output } from '@angular/core';
import { TodoState } from './todoList.component';

@Component({
    selector: 'todo-item',
    standalone: true,
    template: `
    <li class="list-group-item">
        <input class="form-check-input me-1" type="checkbox" [checked]="todoState.done" (change)="updateParent($event)">
        Item: {{todoState.title}}&nbsp;
    </li>`,
    styles: `.todo-item {
        color: red;
    }`,
})
export class TodoItem {
    @Input() todoState!: TodoState;
    onClick = output<TodoState>()

    updateParent(evt: Event) {
        let state = {...this.todoState}
        this.onClick.emit(state);
    }
}