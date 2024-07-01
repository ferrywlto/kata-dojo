import { Component } from "@angular/core";
import { TodoItem } from "./todoItem.component";
@Component({
    standalone: true,
    selector: 'todo-list',
    imports: [TodoItem],
    template: `
        <ul class="list-group">
        @for (todo of todos; track todo) {
            <todo-item [itemText]=todo></todo-item>
        }
        </ul>`,
    styles: ``
})
export class TodoList {
    todos = [
        "Sweeping floor",
        "Leetcode",
        "Play with cats",
    ]
}
