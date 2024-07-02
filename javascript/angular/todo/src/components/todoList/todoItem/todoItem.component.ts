import { Component, Input, Output, output } from '@angular/core';
import { TodoState } from '../models/todoState';
@Component({
    selector: 'todo-item',
    standalone: true,
    templateUrl: './todoItem.component.html',
    styleUrl: './todoItem.component.css',
})
export class TodoItem {
    @Input() state!: TodoState;
    onClick = output<TodoState>()

    updateParent(evt: Event) {
        let state = {...this.state}
        this.onClick.emit(state);
    }
    isOverdue(due: Date): boolean {
        return new Date() > due;
    }
}