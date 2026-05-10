using DamWebAppApril.Models;
using DamWebAppApril.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DamWebAppApril.Controllers
{
    public class DepartmentController : Controller
    {
        // ITIContext context = new ITIContext();
        IDepartmentRepository deptRepo;
        public DepartmentController(IDepartmentRepository _deptRepo)
        {
            deptRepo = _deptRepo;
        }
        public IActionResult Index()
        {
            List<Department> deptList = deptRepo.GetAll();
            return View("Index",deptList);//Model: List<Department>
        }
        #region New
        //link to open page (Get)
        public IActionResult New()
        {
            return View("New");//New ,Model=null
        }
        //Department/SaveNew? name = sd
        //Can handel any reqeut method(get| post)
        [HttpPost]
        public IActionResult SaveNew(Department deptFromRequest)
        {
            //if (this.Request.Method == "POST")
            //{
                if (deptFromRequest.Name != null)//check 
                {
                    //save
                    deptRepo.Add(deptFromRequest);
                    deptRepo.Save();    
                    return RedirectToAction("Index", "Department", routeValues: new { id = deptFromRequest.Id });//Model Null
                }
                //return viwew new
                return View("New", deptFromRequest);//???????? Overload   method attribute
                                                    //View : NEw ,Model ==>Department
            //}
        }
        #endregion
    }
}
