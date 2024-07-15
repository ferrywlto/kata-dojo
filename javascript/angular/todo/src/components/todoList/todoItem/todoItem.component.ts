import { Component, Input, output } from '@angular/core';
import { ReactiveFormsModule } from "@angular/forms"
import {
    trigger,
    state,
    style,
    animate,
    transition,
    keyframes,
  } from '@angular/animations';
import { DatePipe } from '@angular/common';
import { TodoState } from '../../../models/todoState';
import { TodoUIService } from '../../../services/todo-ui.service';
import { TodoInputGroup } from '../../input-group/input-group.component';
@Component({
    selector: 'todo-item',
    standalone: true,
    templateUrl: './todoItem.component.html',
    styleUrl: './todoItem.component.css',
    imports: [ReactiveFormsModule, DatePipe, TodoInputGroup],
    animations: [
        trigger('editMode', [
            state('visible', style({ opacity: 1 })),
            transition('void => visible', [animate('1s', keyframes([
                style({opacity: 0.1, offset: 0.1}),
                style({opacity: 0.6, offset: 0.2}),
                style({opacity: 1, offset: 0.5}),
                style({opacity: 0.2, offset: 0.7}),
              ]))]),
            transition('* => void', [animate('1s')]),
        ])
    ]
})
export class TodoItem {
    constructor(
        public todoUIService: TodoUIService,
        private datePipe: DatePipe, 
    ) { }
    
    @Input() state!: TodoState;
    onDoneChange = output<number>()
    onDeleteClick = output<number>()
    onEdit = output<TodoState>()
    isEditMode = false;

    onSubmit(event: {title: string, due: Date}) {
        this.onEdit.emit({
            id: this.state.id,
            title: event.title,
            due: event.due,
            done: this.state.done,
        });
        this.toggleEditMode();
    }

    notifyDoneChange() {
        this.onDoneChange.emit(this.state.id);
    }
    notifyDeleteClick() {
        this.onDeleteClick.emit(this.state.id);
    }

    textClass() {
        return `text-${this.textColor()} form-check-label`;
    }
    textColor() {
        if (this.state.done)
            return "secondary";
        else if (new Date() > this.state.due)
            return "danger";
        else
            return "primary";
    }
    toggleEditMode() {
        this.isEditMode = !this.isEditMode;
    }
    displayText() {
        return `${this.formatDate(this.state.due)} | ${this.state.title}`;
    }
    formatDate(date: Date) {
        return this.datePipe.transform(date, 'dd/MM/yyyy hh:mm a') || '';
    }
}