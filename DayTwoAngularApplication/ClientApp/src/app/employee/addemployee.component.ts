import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { EmployeeService } from "./employee.service";
import { error } from "protractor";
import { DatePipe } from "@angular/common";
import { get } from "http";

@Component({
  selector:'app-addemployee',
  templateUrl:'./addemployee.component.html'
})
export class AddEmployeeComponent implements OnInit {
  employeeForm: FormGroup;
  title: string = "Add Employee";
  id: number=0;


  public genders = [
    { value: 1, display: 'Male' },
     { value: 2, display: 'Female' }
  ];
  errorMessage: any;


 
  constructor(private _formBuilder: FormBuilder, private _activateRoute: ActivatedRoute,
    private _employeeService: EmployeeService,
    private _router: Router) {
    if (this._activateRoute.snapshot.params["id"]) {
      this.id = this._activateRoute.snapshot.params["id"];
    }

    this.employeeForm = this._formBuilder.group({
      employeeId: 0,
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required]],
      joiningDate: ['', [Validators.required]],
      isComfirm: ['', [Validators.required]],
      gender: ['', [Validators.required]]

    })
   
  }
  save() {
    if (!this.employeeForm.valid) {
      return;
    }
    if (this.id == 0) {
      this._employeeService.saveEmployee(this.employeeForm.value)
        .subscribe((data) => {
          this._router.navigate(['/employee']);
        }, error => this.errorMessage = error)
    }
    else if (this.id >0) {
      this._employeeService.updateEmployee(this.employeeForm.value)
        .subscribe((data) => {
          this._router.navigate(['/employee']);
        }, error => this.errorMessage = error)
    }
  }
  cancel() {
    this._router.navigate(['/employee']);
  }  
  ngOnInit() {
    if (this.id > 0) {
   
      this.title = "Edit Employee";
      this._employeeService.getEmployeeById(this.id)
        .subscribe(data => this.employeeForm.setValue(data), error => this.errorMessage = error);
    }
 
  }
 
}
