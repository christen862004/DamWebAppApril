using DamWebAppApril.Filtters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DamWebAppApril.Controllers
{
    //r/m1
    //r/m2\
    //[Route("r")]
    //[HandelError]
    //[Authorize]
    public class RouteController : Controller
    {
        [HandelError]
       // [AllowAnonymous]
        public IActionFilter r1()
        {
            throw new Exception("action exception");
        }
        public IActionFilter r2()
        {
            throw new Exception("action exception");
        }


        [HttpGet("r1/{age:int}/{name?}",Name ="R1")]//the only way to reach to this action
        public IActionResult M1(int age,string name)//r/r1/22/er
        {
            return Content("m1");
        }
        //Route/m2
        //r2
        //[Route("/r2", Name = "R1")]//the only way to reach to this action
        //r2
        public IActionResult M2()
        {
            return Content("m2");

        }
    }
}
