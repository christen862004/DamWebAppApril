using DamWebAppApril.Models;
//using DamWebAppApril.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DamWebAppApril.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        //Employee/Details/1
        public IActionResult Details(int id)
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
    }
}
