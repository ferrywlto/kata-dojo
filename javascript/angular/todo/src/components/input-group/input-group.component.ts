import { Component, Input, output } from '@angular/core';
import { TodoUIService } from '../../services/todo-ui.service';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'todo-input-group',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './input-group.component.html',
  styleUrl: './input-group.component.css'
})
export class InputGroupComponent {
  constructor(public todoUIService: TodoUIService) { }
  @Input() title!: string;
  @Input() due!: Date;
  onEdit = output<{ title: string, due: Date }>()

  todoForm = this.todoUIService.createReactiveForm();
  get titleControl() { return this.todoForm.get('titleControl'); }
  get dueControl() { return this.todoForm.get('dueControl'); }
  get isFormValid() { return this.todoForm.status === "VALID"; }

  ngOnInit() {
    this.titleControl?.setValue(this.title);
    if (!this.due)
      this.setDueToDefault();
    else
      this.setDueDate(this.due);
  }

  onSubmit() {
    if (this.isFormValid) {
      this.onEdit.emit({
        title: this.titleControl?.value ?? '',
        due: new Date(this.dueControl?.value ?? ''),
      });
      this.clearInput();
    }
  }
  clearInput() {
    this.titleControl?.reset();
    this.setDueToDefault();
  }
  setDueToDefault() {
    this.setDueDate(new Date());
  }
  setDueDate(date: Date) {
    this.dueControl?.setValue(this.transformedDate(date));
  }
  transformedDate(input: Date) {
    const dateStr = input.getFullYear() + '-' +
      ('0' + (input.getMonth() + 1)).slice(-2) + '-' +
      ('0' + input.getDate()).slice(-2) + 'T' +
      ('0' + input.getHours()).slice(-2) + ':' +
      ('0' + input.getMinutes()).slice(-2);
    return dateStr;
  }
}
