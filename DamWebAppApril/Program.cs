using DamWebAppApril.Models;
using DamWebAppApril.Repository;

namespace DamWebAppApril
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. Day6
            // 1) build in service (interface ,class) ,already register
            // 2) build in service (interface ,calss) ,need to register (optional Service)
            builder.Services.AddControllersWithViews();
            // 3) Custom service , need to register
            //builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            //builder.Services.AddScoped<IRepository<Department>, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IService, Service>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.Day7 Middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();//run web app open browser
        }
    }
}
