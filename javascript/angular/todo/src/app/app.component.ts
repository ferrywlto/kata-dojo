import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TodoList } from './todoList.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TodoList],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'todo';
}
