using Microsoft.EntityFrameworkCore;

namespace DayTwoAngularApplication.Models
{
    public class EmployeeDataContext : DbContext
    {
        public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
    }
}
