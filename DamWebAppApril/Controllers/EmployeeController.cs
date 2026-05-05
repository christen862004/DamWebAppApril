using DamWebAppApril.Models;
//using DamWebAppApril.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DamWebAppApril.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            List<Employee> employees = context.Employees.ToList();
            return View("Index", employees);
        }
        #region NEw
        public IActionResult New()
        {
            ViewBag.DeptList = context.Departments.ToList();
            //ViewBag.DeptList = new SelectList( context.Departments.ToList(),"ID","Name");
            return View("New");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//handel internal request only not external by token
        public IActionResult SaveNew(Employee empFromReq)
        {
            if (empFromReq.Name != null && empFromReq.Salary > 7000)
            {
                context.Employees.Add(empFromReq);//id=0;
                context.SaveChanges(); //id identity
                return RedirectToAction("Index", "Employee");
            }
            ViewBag.DeptList = context.Departments.ToList();
           // IEnumerable<SelectListItem> list= context.Departments.ToList()
            return View("New", empFromReq);
        }
        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            //Collect
            Employee EmpModel = context.Employees.FirstOrDefault(e => e.Id == id);
            List<Department> DeptList = context.Departments.ToList();
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
                //save
                Employee EmpFromDB = context.Employees.FirstOrDefault(e => e.Id == EmpFromRequest.Id);
                EmpFromDB.Name=EmpFromRequest.EmpName;
                EmpFromDB.Salary=EmpFromRequest.NetSalary;
                EmpFromDB.ImageURl=EmpFromRequest.ImageURl;
                EmpFromDB.DepartmentID=EmpFromRequest.DepartmentID;
                context.SaveChanges();
                return RedirectToAction(actionName:"Index",controllerName:"Employee");
            }
            EmpFromRequest.DeptList = context.Departments.ToList();//refill incorretc data
            return View("Edit",EmpFromRequest);
        }
        #endregion
        #region Details
        //Employee/Details/1
        public IActionResult Details(int id,string name)
        {
            //need to Send some Extra Info to View 
            string EvalLevel = "Excellent";
            List<Department> DeptList = context.Departments.ToList();
            int Grade = 1;
            //Set on viewdata
            //boxing
            //ViewData["Level"] = EvalLevel;
            ViewData["Grade"] = 1;
            ViewData["DeptList"] = DeptList;
            ViewBag.Level = "good";
            ViewBag.Color = "red";
            ViewData["Color"] = "Blue";

            Employee EmpModel= context.Employees.FirstOrDefault(e=>e.Id== id);
            return View("Details",EmpModel);
        }
        public IActionResult DetailsVM(int id)
        {
            //1) collect data
            //need to Send some Extra Info to View 
            string EvalLevel = "Excellent";
            List<Department> DeptList = context.Departments.ToList();
            int EmpGrade = 1;
            Employee EmpModel = context.Employees.FirstOrDefault(e => e.Id == id);

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
