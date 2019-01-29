using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayTwoAngularApplication.Models
{
    public class EmployeeDataAccessLayer
    {
        private readonly EmployeeDataContext db;
      
        public EmployeeDataAccessLayer(EmployeeDataContext context)
        {
          
            db = context;
        }

      
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return db.Employee.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record   
        public int AddEmployee(Employee employee)
        {
            try
            {
                db.Employee.Add(employee);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee  
        public int UpdateEmployee(Employee employee)
        {
            try
            {
                db.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee  
        public Employee GetEmployeeData(int id)
        {
            try
            {
                Employee employee = db.Employee.Find(id);
                return employee;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee  
        public int DeleteEmployee(int id)
        {
            try
            {
                Employee emp = db.Employee.Find(id);
                db.Employee.Remove(emp);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

    
    }
}
