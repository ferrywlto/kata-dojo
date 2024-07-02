import { Component } from "@angular/core";
import { TodoItem } from "./todoItem.component";
@Component({
    standalone: true,
    selector: 'todo-list',
    imports: [TodoItem],
    template: `
        <ul class="list-group">
        @for (todo of todos; track todo.id) {
            <todo-item [todoState]=todo (onClick)="showClicked($event)"></todo-item>
        }
        </ul>
        <div>{{debug}}</div>`
        ,
    styles: ``
})
export class TodoList {
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
}
export class TodoState {
    id!: number;
    title!: string
    done!: boolean
}