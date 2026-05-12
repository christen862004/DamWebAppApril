using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DamWebAppApril.Models
{
    public class ITIContext:IdentityDbContext<AppliactionUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ITIContext(DbContextOptions<ITIContext> options):base(options)//context inject (ask) options
        {
            
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    //logic
        //    base.OnModelCreating(builder);//must be to migrate
        //}
    }
}
