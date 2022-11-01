import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzTableData, NzTableSortFn, NzTableSortOrder } from 'ng-zorro-antd/table';
import { Employee } from 'src/app/models/employee';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent implements OnInit {
  validateForm!: FormGroup;
  employees:Employee[] = [];
  sortFunctions = {
    surname: this.sortAlpha('surname'),
    firstname: this.sortAlpha('firstname'),
    position: this.sortAlpha('position'),
    positionLevel: this.sortAlpha('positionLevel'),
    startDate: this.sortDate('startDate'),
    email: this.sortAlpha('email'),
    phone: this.sortAlpha('phone'),
  };

  constructor(private _fb: FormBuilder, private _employeesService: EmployeesService) { }

  ngOnInit(): void {
    this.validateForm = this._fb.group({
      surname: [null, [Validators.maxLength(100)]],
      firstname: [null, [Validators.maxLength(100)]]
    });
  }

  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }

    if (this.validateForm.valid) {
      this._employeesService.getAll(
        this.validateForm.controls["surname"].value as string,
        this.validateForm.controls["firstname"].value as string)
        .subscribe(employees => {
          this.employees = employees;
        });
    }
  }

  sortAlpha(prop: string): NzTableSortFn {
    return (a: NzTableData, b: NzTableData, _order?: NzTableSortOrder) => {
      return (a[prop] as string).localeCompare(b[prop] as string);
    }
  }

  sortDate(prop: string): NzTableSortFn {
    return (a: NzTableData, b: NzTableData, _order?: NzTableSortOrder) => {
      const firstDate = new Date(a[prop] as string).getTime();
      const secondDate = new Date(b[prop] as string).getTime();

      return firstDate === secondDate
        ? 0
        : (firstDate < secondDate
          ? 1
          : -1);
    }
  }

}
