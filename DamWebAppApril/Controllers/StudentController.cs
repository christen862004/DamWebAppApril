using DamWebAppApril.Models;
using DamWebAppApril.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DamWebAppApril.Controllers
{
    public class StudentController : Controller
    {
        StudentBL StudentBL=new StudentBL();
        //Stuednt/all
        public IActionResult All()
        {
            List<Student> stds=  StudentBL.GetAll();
            return View("ShowAll",stds);//go to view with name ShowAll,go to view object with type List<Student>
        }
    }
}
