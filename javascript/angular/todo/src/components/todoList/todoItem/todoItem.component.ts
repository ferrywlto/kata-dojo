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
    onDeleteClick = output<number>()

    notifyDoneChange() {
        this.onDoneChange.emit(this.state.id);
    }
    notifyDeleteClick() {
        this.onDeleteClick.emit(this.state.id);
    }
    isOverdue(due: Date): boolean {
        return new Date() > due;
    }
    transformedDate() {
        return this.state.due.toLocaleDateString()
        + " " + this.state.due.toLocaleTimeString();
    } 
    textClass() {
        var color = "";
        if (this.state.done)
            color = "secondary";    
        else if (this.isOverdue(this.state.due))
            color = "danger"
        else 
            color = "primary"

        return `text-${color} form-check-label`;
    }
}