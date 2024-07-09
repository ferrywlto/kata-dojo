import { Routes } from '@angular/router';
import { TodoList } from '../components/todoList/todoList.component';
import { NotFound } from '../components/not-found/not-found.component';

export const routes: Routes = [
    { path: 'todo', title: 'Todo', component: TodoList, data: {animation: 'Todo'} },
    { path: '**', title: 'Not found', component: NotFound, data: {animation: 'NotFound'} },
];
