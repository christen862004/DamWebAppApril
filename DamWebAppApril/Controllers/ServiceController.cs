using DamWebAppApril.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DamWebAppApril.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IService service;
        public ServiceController(IService service)//object create - reused ???
        {
            this.service = service;
        }
        //Service/Index
        public IActionResult Index()
        {
            ViewBag.Id = service.Id;
            return View();
        }
    }
}
