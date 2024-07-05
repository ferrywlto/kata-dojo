import { Component } from "@angular/core";
import { AbstractControl, FormControl, FormGroup, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from "@angular/forms"
import { TodoItem } from "./todoItem/todoItem.component";
import { TodoState } from "./models/todoState";
@Component({
    standalone: true,
    selector: 'todo-list',
    imports: [TodoItem, ReactiveFormsModule],
    templateUrl: './todoList.component.html',
    styleUrl: './todoList.component.css',
})
export class TodoList {
    currentDate: Date = new Date();
    showDone: boolean = false;
    todos: TodoState[] = [
        { id: 1, title: "Sweeping floor",  done: false, due: new Date(2024,6,15,21,45) },
        { id: 2, title: "Leetcode", done: true, due: new Date(2024,7,1,23,59) },
        { id: 3, title: "Play with cats", done: false, due: new Date(2024,5,23) },
    ]
    todoTitle: string = "hello";

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
    }
    isFormValid() {
        return this.todoForm.status === "VALID";
    }

}