import { Component } from '@angular/core';
import { ChildrenOutletContexts, RouterOutlet } from '@angular/router';
import { TodoList } from '../components/todoList/todoList.component';
import { style, transition, trigger, query, animateChild, animate, group } from '@angular/animations';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TodoList],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  animations: [
    trigger('routeAnimation', [
      transition('Todo <=> NotFound', [
        style({position: 'relative'}),
        query(':enter, :leave', [
          style({
            position: 'absolute',
            top: 0,
            left: 0,
            width: '100%',
          }),
        ]),
        query(':enter', [style({left: '-100%'})], {optional: true}),
        query(':leave', animateChild(), {optional: true}),
        group([
          query(':leave', [animate('300ms ease-out', style({left: '100%'}))], {optional: true}),
          query(':enter', [animate('300ms ease-out', style({left: '0%'}))], {optional: true}),
        ]),
      ])
    ])
  ],
})
export class AppComponent {
  title = 'todo';
  constructor(private contexts: ChildrenOutletContexts) {}
  getRouteAnimationData() {
    return this.contexts
      .getContext('primary')?.route?.snapshot?.data?.['animation'];
  }
}
