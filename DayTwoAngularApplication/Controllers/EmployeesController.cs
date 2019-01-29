using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DayTwoAngularApplication.Models;

namespace DayTwoAngularApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDataContext _context;
        
        public EmployeeController(EmployeeDataContext context)
        {
            _context = context;
        }



        [HttpGet]
        [Route("api/Employee/Index")]
        public IEnumerable<Employee> Index()
        {
            var list = _context.Employee.ToList();
            return list;
        }

        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create([FromBody] Employee employee)
        {
            try
            {
                
                _context.Employee.Add(employee);
                _context.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public Employee Details(int id)
        {
            try
            {
                Employee employee = _context.Employee.Find(id);
          
                return employee;
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        [Route("api/Employee/Edit")]
        public int Edit([FromBody]Employee employee)
        {
            _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return 1;
        }

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public int Delete(int id)
        {
            Employee emp = _context.Employee.Find(id);
            _context.Employee.Remove(emp);
            _context.SaveChanges();
            return 1;
        }


    }
}