import { Injectable } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class TodoUIService {

  constructor() { }

  createReactiveForm() {
    return new FormGroup({
      titleControl: new FormControl('', [
        Validators.minLength(4),
        Validators.required,
      ]),
      dueControl: new FormControl('', [
        this.dueDateCannotPast(),
        Validators.required,
      ]),
    })
  }

  private dueDateCannotPast(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      return Date.parse(control.value) < Date.now() ?
        { pastDueDate: { value: control.value } }
        : null;
    };
  }
}
