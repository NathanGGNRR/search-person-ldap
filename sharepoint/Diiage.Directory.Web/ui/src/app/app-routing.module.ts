import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MsalGuard } from '@azure/msal-angular';
import { AboutComponent } from './pages/about/about.component';
import { EmployeeComponent } from './pages/employee/employee.component';
import { EmployeesComponent } from './pages/employees/employees.component';
import { ApplicationInsights } from '@microsoft/applicationinsights-web';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'employees' },
  { path: 'employees', component: EmployeesComponent, canActivate: [MsalGuard] },
  { path: 'employees/:id', component: EmployeeComponent, canActivate: [MsalGuard] },
  { path: 'about', component: AboutComponent, canActivate: [MsalGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
