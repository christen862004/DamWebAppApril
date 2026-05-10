using DamWebAppApril.Models;
using Microsoft.AspNetCore.Mvc;

namespace DamWebAppApril.Controllers
{
    public class StateController : Controller
    {
        //int counter = 0;
        public IActionResult SetSession(string name,int age)
        {
            //logic
            //Employee =>json ==>Setstring
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);
          //  counter++;
            return Content($"Session Save Success");
        }
        //the same controller
        public IActionResult GetSession()
        {
            //logic
            //read session
            string? n=HttpContext.Session.GetString("Name");
            int? a=HttpContext.Session.GetInt32("Age");

            return Content($"Name={n} \t Age={a}");
        }

        //set get
        public IActionResult SetCookie(string name,int age)
        {
            //Session cookie 
            HttpContext.Response.Cookies.Append("EmpName", name);
            //Presistent Cookie Exipration 
            CookieOptions options = new CookieOptions();
            options.Expires=DateTimeOffset.Now.AddDays(1);

            HttpContext.Response.Cookies.Append("Age", age.ToString(), options);
            
            return Content("cookie Success Save");
        }
        //at any Controiller
        public IActionResult GetCookie()
        {
            string? n=HttpContext.Request.Cookies["EmpName"];
            string? a=HttpContext.Request.Cookies["Age"];

            return Content($"Name={n}\t Age={a}");
        }
    }
}
