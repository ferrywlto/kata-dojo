import { Component } from "@angular/core";
import { TodoItem } from "./todoItem/todoItem.component";
import { TodoState } from "./models/todoState";
@Component({
    standalone: true,
    selector: 'todo-list',
    imports: [TodoItem],
    templateUrl: './todoList.component.html',
    styleUrl: './todoList.component.css',
})
export class TodoList {
    showDone: boolean = false;
    todos: TodoState[] = [
        { id: 1, title: "Sweeping floor", done: false },
        { id: 2, title: "Leetcode", done: true },
        { id: 3, title: "Play with cats", done: false },
    ]
    debug: string = "";
    showClicked(event: TodoState)
    {
        this.debug = event.id + " | " + event.title + " | " + event.done;
        let targetState = this.todos.find(x => x.id === event.id);
        if (targetState)
        {
            targetState.done = !targetState?.done
        }
    }
    toggleShowDone()
    {
        this.showDone = !this.showDone;
    }
}