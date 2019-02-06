import { Injectable } from '@angular/core';
import { Employee } from './employee.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  formData : Employee;

  readonly rootURL = "http://6c6d7200.ngrok.io/api"
  
  constructor(private http : HttpClient) { }

  postNewTblEmployee(formData : Employee) {
    return this.http.post(this.rootURL+"/Employee",formData);
  }
}
