import { Component } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms"
import { TodoItem } from "./todoItem/todoItem.component";
import { Router } from "@angular/router";
import { TodoService } from "../../services/todo.service";
import { TodoInputGroup } from "../input-group/input-group.component";
@Component({
    standalone: true,
    selector: 'todo-list',
    imports: [
        ReactiveFormsModule,
        TodoItem,
        TodoInputGroup,
    ],
    templateUrl: './todoList.component.html',
    styleUrl: './todoList.component.css',
})
export class TodoList {
    constructor(
        private router: Router,
        public todoService: TodoService,
    ) { }
    
    onSubmit(event: {title: string, due: Date}) {
        this.todoService.add(
            event.title ?? '',
            event.due ?? '');
    }
    
    showDone: boolean = false;
    get todos() { return this.todoService.getAll(); }

    onBackClick() {
        this.router.navigateByUrl('/');
    }

    toggleShowDone() {
        this.showDone = !this.showDone;
    }
}