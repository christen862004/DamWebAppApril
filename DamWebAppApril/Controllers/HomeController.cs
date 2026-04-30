using DamWebAppApril.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DamWebAppApril.Controllers
{
    /***
     1) Class name end with Controller
     2) Class Inherit Controller
     */
    public class HomeController : Controller
    {
        //home/index create object HomeController h=new(); h.Index()
        /**
         *method call from url "Action" ==>url Endpoint
         * 1) Must Be Public
         * 2) Must Be Non Static
         * 3) Cant Overload (only one case)
         */
        //endpoint : /Home/ShowMsg
        public ContentResult ShowMsg()
        {
            //logic
            //decalre emplou
            ContentResult result=new ContentResult();
            //set data
            result.Content = "Hello";
            //resturn
            
            return result;
        }
        //Home/showView
        public ViewResult ShowView()
        {
            //logic
            //decalre
            ViewResult result=new ViewResult();
            //set info
            result.ViewName = "View1";

            //return
            return result;
        }
        //public ViewResult View(string viewNAme)
        //{
        //    //decalre
        //    ViewResult result = new ViewResult();
        //    //set info
        //    result.ViewName = viewNAme;

        //    //return
        //    return result;
        //}
        //Home/ShowMix?id=1&no=10&name=ahmed (query String)
        //Home/ShowMix/99?no=10&name=ahmed (query String)
        public IActionResult ShowMix(int id,int no,string name)
        {
            if (id % 2 == 0)
            {
                //logic
                return View("View1");
            }
            else
            {
                return Content("Heelo");
            }
        }

        /**
         * return type of action
         * 1) Content  ==> ContentResult
         * 2) View     ==> ViewResult
         * 3) Json     ==> JsonResult
         * 4) NotFound ==> NotFoundResult
         * 5) unAuthorize> UnauthrouzeResult
         * ......
         */

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
