import { Component } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms"
import { TodoItem } from "./todoItem/todoItem.component";
import { Router } from "@angular/router";
import { TodoService } from "../../services/todo.service";
import { TodoUIService } from "../../services/todo-ui.service";
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
        public todoService: TodoService,
        public todoUIService: TodoUIService
    ) { }

    ngOnInit() {
        this.dueControl?.setValue(this.todoUIService.transformedDate(new Date()));
    }

    todoForm = this.todoUIService.createReactiveForm();
    get titleControl() { return this.todoForm.get('titleControl'); }
    get dueControl() { return this.todoForm.get('dueControl'); }
    get isFormValid() { return this.todoForm.status === "VALID"; }
    
    onSubmit() {
        if (this.isFormValid) {
            this.todoService.add(
                this.titleControl?.value ?? '',
                new Date(this.dueControl?.value ?? '')
            );
            this.clearInput();
        }
    }
    
    showDone: boolean = false;
    get todos() { return this.todoService.getAll(); }

    clearInput() {
        this.titleControl?.reset();
        this.dueControl?.reset();
    }

    onBackClick() {
        this.router.navigateByUrl('/');
    }

    toggleShowDone() {
        this.showDone = !this.showDone;
    }
}