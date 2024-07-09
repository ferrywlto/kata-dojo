import { Component, Input, Output, output } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from "@angular/forms"
import { DatePipe } from '@angular/common';
import { TodoState } from '../models/todoState';
@Component({
    selector: 'todo-item',
    standalone: true,
    templateUrl: './todoItem.component.html',
    styleUrl: './todoItem.component.css',
    imports: [ReactiveFormsModule, DatePipe],
})
export class TodoItem {
    @Input() state!: TodoState;
    onDoneChange = output<number>()
    onDeleteClick = output<number>()
    onEdit = output<TodoState>()

    isEditMode = false;
    todoForm = new FormGroup({
        titleControl: new FormControl('', [
            Validators.minLength(4),
            Validators.required,
        ]),
        dueControl: new FormControl('',[
            this.dueDateCannotPast(),
            Validators.required,
        ]),
    });
    get titleControl() { return this.todoForm.get('titleControl'); }
    get dueControl() { return this.todoForm.get('dueControl'); }
    dueDateCannotPast(): ValidatorFn {
        return (control: AbstractControl): ValidationErrors | null => {
            return Date.parse(control.value) < Date.now() ?
                { pastDueDate: { value: control.value } }
                : null;
        };
    }
    onSubmit() {
        if (this.isFormValid) {
            this.onEdit.emit({
                id: this.state.id,
                title: this.titleControl?.value ?? '',
                due: new Date(this.dueControl?.value ?? ''),
                done: this.state.done,
            });
            this.toggleEditMode();
        }
    }
    get isFormValid() {
        return this.todoForm.status === "VALID";
    }

    notifyDoneChange() {
        this.onDoneChange.emit(this.state.id);
    }
    notifyDeleteClick() {
        this.onDeleteClick.emit(this.state.id);
    }
    isOverdue(due: Date): boolean {
        return new Date() > due;
    }
    transformedDate(input: Date) {
        const dateStr = input.getFullYear() + '-' +
        ('0' + (input.getMonth() + 1)).slice(-2) + '-' +
        ('0' + input.getDate()).slice(-2) + 'T' +
        ('0' + input.getHours()).slice(-2) + ':' +
        ('0' + input.getMinutes()).slice(-2);   
        return dateStr;
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
    toggleEditMode() {
        this.isEditMode = !this.isEditMode;
        if (this.isEditMode) {
            this.titleControl?.setValue(this.state.title);
            this.dueControl?.setValue(this.transformedDate(this.state.due));
        }
    }
}