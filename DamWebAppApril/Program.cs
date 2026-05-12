using DamWebAppApril.Filtters;
using DamWebAppApril.Models;
using DamWebAppApril.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
            //builder.Services.AddControllersWithViews(options => {
            //    options.Filters.Add(new HandelErrorAttribute());//global filter attribute
            //});
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ITIContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));

            });//register options ,ITIContext
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(30);

            });//register session service ==>Middleware +
            
            builder.Services.AddIdentity<AppliactionUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;

            }).AddEntityFrameworkStores<ITIContext>();
            //register all manager +determine auth schem
            
            // 3) Custom service , need to register
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IService, Service>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.Day7 Middleware
            #region Custom PipLine
            //use nee to delegate (httpcontext,next) 
            //inline middleware
            //app.Use(async(httpcontext, nextMiddleware) => {
            //    //httpcontext.Request.metho
            //    await httpcontext.Response.WriteAsync("1- Middleware 1 \n");
            //    await nextMiddleware.Invoke();
            //    await httpcontext.Response.WriteAsync("1-1 Middleware 1-1 \n");

            //});
            //app.Use(async (httpcontext, nextMiddleware) => {
            //    await httpcontext.Response.WriteAsync("2- Middleware 2 \n");
            //    await nextMiddleware.Invoke();
            //    await httpcontext.Response.WriteAsync("2-2 Middleware 2-2 \n");

            //});
            //app.Run(async(httpcontext) => { 
            //    await httpcontext.Response.WriteAsync("3- Terminate 3 \n");
            //});
            #endregion

            #region default PIPEINE
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//check if request ==>wwwroote

            app.UseRouting();//mapping "Security"

            app.UseSession();//middlewar enot configure

            app.UseAuthorization();

            #region Naming Converntion Route
            //app.MapControllerRoute(name: "Route1", pattern: "r1/{age:int:range(20,60)}/{name?}"
            //    , defaults: new { controller ="Route",action="M1"});    
            //app.MapControllerRoute(name: "Route1", pattern: "r1"
            //    , defaults: new { controller ="Route",action="M1"});
            //app.MapControllerRoute(name: "Route2", pattern: "r2"
            //   , defaults: new { controller = "Route", action = "M2" });
            //app.MapControllerRoute(name: "Route1", pattern: "{controller}/{action}/{id?}"
            // , defaults: new { controller = "Home", action = "index" });

            #endregion



            //Staff Decalre ,execute
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            app.Run();//run web app open browser
        }
    }
}
