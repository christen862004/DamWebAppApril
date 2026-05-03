using DamWebAppApril.Models;
using Microsoft.AspNetCore.Mvc;

namespace DamWebAppApril.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            List<Department> deptList = context.Departments.ToList();
            return View("Index",deptList);//Model: List<Department>
        }
    }
}
