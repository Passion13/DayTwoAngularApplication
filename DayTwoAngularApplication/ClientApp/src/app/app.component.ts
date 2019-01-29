import { Component } from '@angular/core';
import { EmployeeService } from './employee/employee.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
  , providers: [EmployeeService]
})
export class AppComponent {
  title = 'app';
}
