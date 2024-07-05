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
    currentDate: Date = new Date();
    showDone: boolean = false;
    todos: TodoState[] = [
        { id: 1, title: "Sweeping floor",  done: false, due: new Date(2024,6,15,21,45) },
        { id: 2, title: "Leetcode", done: true, due: new Date(2024,7,1,23,59) },
        { id: 3, title: "Play with cats", done: false, due: new Date(2024,5,23) },
    ]
    todoTitle: string = "hello";
    dueDate = new Date().toISOString().slice(0,16);

    updateDone(id: number)
    {
        let targetState = this.todos.find(x => x.id === id);
        if (targetState)
        {
            targetState.done = !targetState?.done
        }
    }
    removeTodo(id: number)
    {
        this.todos = this.todos.filter(x => x.id !== id);
    }
    toggleShowDone()
    {
        this.showDone = !this.showDone;
    }
    todoCount()
    {
        console.log(this.dueDate);
        return this.todos.length;
    }
}