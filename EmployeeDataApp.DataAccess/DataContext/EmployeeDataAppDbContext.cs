using EmployeeDataApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDataApp.DataAccess.DataContext
{
    public class EmployeeDataAppDbContext : DbContext
    {
        public EmployeeDataAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
