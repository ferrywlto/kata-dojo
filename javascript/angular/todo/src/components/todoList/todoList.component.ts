import { Component } from "@angular/core";
import { AbstractControl, FormControl, FormGroup, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from "@angular/forms"
import { TodoItem } from "./todoItem/todoItem.component";
import { TodoState } from "./models/todoState";
import { max } from "rxjs";
@Component({
    standalone: true,
    selector: 'todo-list',
    imports: [TodoItem, ReactiveFormsModule],
    templateUrl: './todoList.component.html',
    styleUrl: './todoList.component.css',
})
export class TodoList {
    showDone: boolean = false;
    todos: TodoState[] = [
        { id: 1, title: "Sweeping floor",  done: false, due: new Date(2024,6,15,21,45) },
        { id: 2, title: "Leetcode", done: true, due: new Date(2024,7,1,23,59) },
        { id: 3, title: "Play with cats", done: false, due: new Date(2024,5,23) },
    ]
    todoForm = new FormGroup({
        titleControl: new FormControl('', [
            Validators.minLength(4),
            Validators.required,
        ]),
        dueControl: new FormControl(new Date().toISOString().slice(0, 16),[
            this.dueDateCannotPast(),
            Validators.required,
        ]),
    });
    get titleControl() { return this.todoForm.get('titleControl'); }
    get dueControl() { return this.todoForm.get('dueControl'); }
    get isFormValid() {
        return this.todoForm.status === "VALID";
    }
    
    dueDateCannotPast(): ValidatorFn {
        return (control: AbstractControl): ValidationErrors | null => {
            return Date.parse(control.value) < Date.now() ?
                { pastDueDate: { value: control.value } }
                : null;
        };
    }
    updateDone(id: number) {
        let targetState = this.todos.find(x => x.id === id);
        if (targetState) {
            targetState.done = !targetState?.done
        }
    }
    addTodo() {
        let max_id;
        if (this.todos.length > 0) {
            max_id = this.todos.map(x => x.id)
                .reduce((prev, curr) => Math.max(prev, curr)) + 1;
        }
        else max_id = 1;
        console.log(`max_id: ${max_id}`);
        let date = new Date(this.dueControl?.value ?? '');
        this.todos.push({
            id: max_id,
            done: false,
            title: this.titleControl?.value ?? '',
            due: date,
        })
        this.clearInput();
    }
    clearInput() {
        this.titleControl?.reset();
        this.dueControl?.reset();
    }
    removeTodo(id: number) {
        this.todos = this.todos.filter(x => x.id !== id);
    }
    toggleShowDone() {
        this.showDone = !this.showDone;
    }
    todoCount() {
        return this.todos.length;
    }
    onSubmit() {
        console.log(this.todoForm.value);
    }
    onAddClick() {
        console.log(this.todoForm.status);
        this.addTodo();
    }
}