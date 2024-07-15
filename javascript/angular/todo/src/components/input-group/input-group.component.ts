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
    if(!this.due)
      this.setDueToDefault();
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
    this.dueControl?.setValue(this.todoUIService.transformedDate(new Date()));
  }
}
