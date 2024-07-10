import { Component } from "@angular/core";
import { AbstractControl, FormControl, FormGroup, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from "@angular/forms"
import { TodoItem } from "./todoItem/todoItem.component";
import { Router } from "@angular/router";
import { TodoService } from "../../services/todo.service";
@Component({
    standalone: true,
    selector: 'todo-list',
    imports: [TodoItem, ReactiveFormsModule],
    templateUrl: './todoList.component.html',
    styleUrl: './todoList.component.css',
})
export class TodoList {
    constructor(
        private router: Router,
        public todoService: TodoService
    ) { }
    
    showDone: boolean = false;

    todoForm = new FormGroup({
        titleControl: new FormControl('', [
            Validators.minLength(4),
            Validators.required,
        ]),
        dueControl: new FormControl(this.transformedDate(new Date()),[
            this.dueDateCannotPast(),
            Validators.required,
        ]),
    });
    get titleControl() { return this.todoForm.get('titleControl'); }
    get dueControl() { return this.todoForm.get('dueControl'); }
    get isFormValid() { return this.todoForm.status === "VALID"; }
    get todos() { return this.todoService.getAll(); }

    dueDateCannotPast(): ValidatorFn {
        return (control: AbstractControl): ValidationErrors | null => {
            return Date.parse(control.value) < Date.now() ?
                { pastDueDate: { value: control.value } }
                : null;
        };
    }

    transformedDate(input: Date) {
        const date = input;
        const dateStr = date.getFullYear() + '-' +
        ('0' + (date.getMonth() + 1)).slice(-2) + '-' +
        ('0' + date.getDate()).slice(-2) + 'T' +
        ('0' + date.getHours()).slice(-2) + ':' +
        ('0' + date.getMinutes()).slice(-2);   
        return dateStr;
    }

    clearInput() {
        this.titleControl?.reset();
        this.dueControl?.reset();
    }

    toggleShowDone() {
        this.showDone = !this.showDone;
    }

    onSubmit() {
        if (this.isFormValid) {
            this.todoService.add(
                this.titleControl?.value ?? '',
                new Date(this.dueControl?.value ?? '')
            );
            this.clearInput();
        }
    }

    onBackClick() {
        this.router.navigateByUrl('/');
    }
}