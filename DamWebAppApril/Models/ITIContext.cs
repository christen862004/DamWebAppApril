using Microsoft.EntityFrameworkCore;

namespace DamWebAppApril.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ITIContext(DbContextOptions<ITIContext> options):base(options)//context inject (ask) options
        {
            
        }
    }
}
