import { Component, Inject, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeeService } from './employee.service';


@Component({

  templateUrl: './employeeList.component.html'
})
export class EmployeeListComponent {
  public Employees: Employee[];

  constructor(public http: Http, private _router: Router, private _employeeService: EmployeeService) {
    this.getEmployees();
    
  }

  getEmployees() {
   
    this._employeeService.getEmployees()
      .subscribe(data => {
        console.log(data);
        this.Employees = data;
      })
 

  }
  deleteEmployee(employeeId) {
    var success = confirm("Do you want to delete this employee?");
    if (success) {
      this._employeeService.deleteEmployee(employeeId).subscribe((data) => {
        this.getEmployees();
      }, error => console.error(error))
    }
  }
 
}

interface Employee {
  employeeId: number,
  firstName: string,
  lastLame: string,
  email: string,
  joiningDate: Date,
  iscomfirm: boolean,
  gender: number

}
