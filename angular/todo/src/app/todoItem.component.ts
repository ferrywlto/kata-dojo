import { Component } from '@angular/core';

@Component({
    selector: 'todo-item',
    standalone: true,
    template: `
    <div class="todo-item">
        Item: {{itemText}}<button type="button" class="btn btn-primary">123</button>
    </div>`,
    styles: `.todo-item {
        color: red;
    }`,
})
export class TodoItem {
    itemText = 'todo item';
}