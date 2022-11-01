import { AuthentificationService } from './authentification.service';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Employee } from '../models/employee';
import { map } from "rxjs/operators";

 interface EmployeesResponse {
     employees: Employee[]
 }

@Injectable({
    providedIn: 'root'
})
export class EmployeesService {
    private readonly _endpoint = 'employees';

    constructor(private _apiService: ApiService, private authService: AuthentificationService) {
    }

    getAll(surname: string, firstname: string): Observable<Employee[]> {
        return this._apiService.get<EmployeesResponse>(
            `${this._endpoint}?surname=${surname ? encodeURIComponent(surname) : ''}&firstname=${firstname ? encodeURIComponent(firstname) : ''}`, this.authService.isAuthenticated)
            .pipe(map(r => r.employees));
    }

    get(id: number): Observable<Employee> {
        return this._apiService.get<Employee>(
            `${this._endpoint}/${id}`, this.authService.isAuthenticated);
    }

    sendSummary(id: number): Observable<any> {
        return this._apiService.post(
            `${this._endpoint}/${id}/sendSummary`, this.authService.isAuthenticated);
    }
}
