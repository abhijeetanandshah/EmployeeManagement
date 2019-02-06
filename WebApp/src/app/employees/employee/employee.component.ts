import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/shared/employee.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor(private service : EmployeeService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form? : NgForm){
    if(form!=null)
      form.resetForm();
    this.service.formData = {
      EmployeeID : null,
      Name : '',
      Gender: '',
      DateOfBirth: null,
      City: '',
      EmployeeCode: '', 
      Mobile: '',
      Position: ''
    }
  }
  onSubmit(form : NgForm){
    this.insertRecord(form);
  }
  insertRecord(form : NgForm){
    this.service.postNewTblEmployee(form.value).subscribe(res =>{
      this.resetForm(form);
    });
  }
}
