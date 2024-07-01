import { Component, Input } from '@angular/core';

@Component({
    selector: 'todo-item',
    standalone: true,
    template: `
    <li class="list-group-item">
        <input class="form-check-input me-1" type="checkbox" value="" aria-label="...">
        Item: {{itemText}}&nbsp;
    </li>`,
    styles: `.todo-item {
        color: red;
    }`,
})
export class TodoItem {
    @Input() itemText: string = 'todo item';
}