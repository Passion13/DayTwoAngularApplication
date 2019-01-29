using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayTwoAngularApplication.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime JoiningDate { get; set; }
        public bool IsComfirm { get; set; }
        public Gender Gender { get; set; }
    }
    public enum Gender {
        Male=1,
        Female,
        Other
    }
}
