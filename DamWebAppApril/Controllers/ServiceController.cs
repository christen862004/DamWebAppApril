using DamWebAppApril.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DamWebAppApril.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IService service;
        
        //[Authorize]
        public IActionResult Welcome()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                Claim? idClaim= User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                Claim? addressClaim = User.Claims.FirstOrDefault(c => c.Type == "Address");
                string? id = idClaim?.Value;
                string? name=User.Identity.Name;
                string? address = addressClaim?.Value;
                //checkrole
                bool isAdmin=User.IsInRole("Admin");


                return Content($"Hello {name} with id={id} \t address={address}" );
            }
            //authorize ==>welcoe namer 
            //Gust =>welcome Gust
            return Content("Hello Gust");
        }

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
