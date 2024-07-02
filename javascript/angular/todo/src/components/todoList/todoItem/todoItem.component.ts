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
    onDoneChange = output<number>()

    notifyDoneChange(evt: Event) {
        this.onDoneChange.emit(this.state.id);
    }
    isOverdue(due: Date): boolean {
        return new Date() > due;
    }
}