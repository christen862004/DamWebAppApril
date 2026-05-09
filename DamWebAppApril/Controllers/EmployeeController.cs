using DamWebAppApril.Models;
using DamWebAppApril.Repository;

//using DamWebAppApril.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DamWebAppApril.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepository EmpRepo;
        IDepartmentRepository DeptRepo;
        public EmployeeController(IEmployeeRepository empRepo, IDepartmentRepository deptRepo)
        {
            EmpRepo = empRepo;//dont create ,ask about object implement interface 
            DeptRepo = deptRepo;
        }
        // ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            List<Employee> employees = EmpRepo.GetAll();
            return View("Index", employees);
        }
        //Employee/CheckSalary?Salary=900
        public IActionResult CheckSalary(int Salary,int DepartmentID)
        {
            if (Salary > 7000)
                return Json(true);
            return Json("Salary Must Be More Than 7000");
        }
        #region NEw
        public IActionResult New()
        {
            ViewBag.DeptList = DeptRepo.GetAll();
            //ViewBag.DeptList = new SelectList( context.Departments.ToList(),"ID","Name");
            return View("New");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//handel internal request only not external by token
        public IActionResult SaveNew(Employee empFromReq)
        {
            //if (empFromReq.Name != null && empFromReq.Salary > 7000)
            if(ModelState.IsValid==true)
            {
                try
                {
                    EmpRepo.Add(empFromReq);//id=0;deptiId=0
                    EmpRepo.Save();
                    return RedirectToAction("Index", "Employee");
                }catch(Exception ex)
                {
                    //send exception view span department message error
                    //ModelState.AddModelError("DepartmentID", "Please Select Department");
                    ModelState.AddModelError("anyKey",ex.InnerException.Message);//Display in div
                }
            }
            ViewBag.DeptList = DeptRepo.GetAll();
           // IEnumerable<SelectListItem> list= context.Departments.ToList()
            return View("New", empFromReq);
        }
        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            //Collect
            Employee EmpModel = EmpRepo.GetByID(id);
            List<Department> DeptList = DeptRepo.GetAll();
            if(EmpModel == null) {
                return NotFound();
            }
            //delclare & map
            EmpWithDeptListViewModel empVM = new EmpWithDeptListViewModel()
            {
                Id = EmpModel.Id,
                EmpName = EmpModel.Name,
                NetSalary = EmpModel.Salary,
                DepartmentID = EmpModel.DepartmentID,
                ImageURl = EmpModel.ImageURl,
                DeptList = DeptList
            };
            //retunr
            return View("Edit", empVM);//view =>Edit ,Model =>EmpWithDeptListViewModel
        }
        /**
         * /Employee/SaveEdit/1
            Name=ahmed,Salary=10000,ImageURl=m.png,DepartmentID=1
         */
        //public IActionResult SaveEdit(int id,string name,string imageURl,int DepartmentID,int salary)
        [HttpPost]
        public IActionResult SaveEdit(EmpWithDeptListViewModel EmpFromRequest)
        {
            if (EmpFromRequest.EmpName != null)
            {
                //mapping package auomapper
                Employee EmpObj = new Employee();
                EmpObj.Id = EmpFromRequest.Id;
                EmpObj.Name=EmpFromRequest.EmpName;
                EmpObj.Salary=EmpFromRequest.NetSalary;
                EmpObj.ImageURl=EmpFromRequest.ImageURl;
                EmpObj.DepartmentID=EmpFromRequest.DepartmentID;

                EmpRepo.Update(EmpObj);
                EmpRepo.Save();
                return RedirectToAction(actionName:"Index",controllerName:"Employee");
            }
            EmpFromRequest.DeptList = DeptRepo.GetAll();
            return View("Edit",EmpFromRequest);
        }
        #endregion

        #region Details
        //Employee/Details/1
        public IActionResult Details(int id,string name)
        {
            //need to Send some Extra Info to View 
            string EvalLevel = "Excellent";
            List<Department> DeptList = DeptRepo.GetAll();
            int Grade = 1;
            //Set on viewdata
            //boxing
            //ViewData["Level"] = EvalLevel;
            ViewData["Grade"] = 1;
            ViewData["DeptList"] = DeptList;
            ViewBag.Level = "good";
            ViewBag.Color = "red";
            ViewData["Color"] = "Blue";

            Employee EmpModel= EmpRepo.GetByID(id);
            return View("Details",EmpModel);
        }
        public IActionResult DetailsVM(int id)
        {
            //1) collect data
            //need to Send some Extra Info to View 
            string EvalLevel = "Excellent";
            List<Department> DeptList = DeptRepo.GetAll();
            int EmpGrade = 1;
            Employee EmpModel = EmpRepo.GetByID(id);

            //3) Map
            //2) decalre VM
            EmpWithGradeLevelDeptListViewModel empVM = new() { 
                EmpId=EmpModel.Id,
                EmpName=EmpModel.Name,
                Grade=EmpGrade,
                DeptList=DeptList,
                Color="red"
            };
            //empVM.EmpName = EmpModel.Name;
            //4) return to view
            return View("DetailsVM", empVM);//go to view Model ==> EmpWithGradeLevelDeptListViewModel
        }
        #endregion
    }
}
