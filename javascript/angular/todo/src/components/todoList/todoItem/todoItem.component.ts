import { Component, Input, Output, output } from '@angular/core';
import { TodoState } from '../models/todoState';
@Component({
    selector: 'todo-item',
    standalone: true,
    templateUrl: './todoItem.component.html',
    styleUrl: './todoItem.component.css',
})
export class TodoItem {
    @Input() todoState!: TodoState;
    onClick = output<TodoState>()

    updateParent(evt: Event) {
        let state = {...this.todoState}
        this.onClick.emit(state);
    }
}