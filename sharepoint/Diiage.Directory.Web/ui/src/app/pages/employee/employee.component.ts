import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from 'src/app/models/employee';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent implements OnInit {
  employee: Employee | null = null;

  constructor(
    private _employeesService: EmployeesService,
    private _activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this._activatedRoute.paramMap.subscribe((p) => {
      this._employeesService.get(Number(p.get('id'))).subscribe((e) => {
        this.employee = e;
      });
    });
  }

  sendSummary() {
    if (this.employee) {
      this._employeesService
        .sendSummary(this.employee.id)
        .subscribe(() => {
          window.alert('La fiche vous a été envoyée par mail.');
        });
    }
  }
}
