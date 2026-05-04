using DamWebAppApril.Models;
using Microsoft.AspNetCore.Mvc;

namespace DamWebAppApril.Controllers
{
    public class BindController : Controller
    {
        //Method not static - public - cant opverload only in some cases
        //bind/test : get
        [HttpGet]
        public IActionResult Test()
        { return Content("T1"); }

        //bind/test : post
        //bind/test?id=12&name=ahmed : post
        //bind/test/44?name=ahmed : post
        [HttpPost]
        public IActionResult Test(int id,string name)//TEst() ,Test(10),Test(10,ahmed)
        { return Content("T with paramet"); }


        /*
         <form action="http://localhost:36786/Bind/testPrimitive/1" method="get">
             <input type="number" id="age" name="age"><br>
             <input type="number" id="id" name="id"><br><!--QS ,formData-->
            <input type="checkbox" id="color" name="Color[1]" value="red"><br>
            <input type="checkbox" id="color" name="Color[0]" value="blue"><br>
            <input type="text" id="color" name="PhoneBook[@item.Name]" ><br>
            <input type="text" id="empNAme" name="Employees[0].name" ><br>
            

        <input type="submit" value="Send">
    </form>
         */
        //Bind/TestPrimitive/99?age=12&name=ahmed
        //Bind/TestPrimitive?age=12&name=ahmed&id=99
        //http://localhost:36786/bind/TestPrimitive?color[1]=red&color[0]=blue
        public IActionResult TestPrimitive(int age ,string name,int id,string[] color)
        {
            return Content($"{age}\t {name}");
        }

        //Test Collection list,
        //Bind/TestDic?name=christen&PhoneBook[ahmed]=123&PhoneBook[moh]=456
        public IActionResult TestDic(string name,Dictionary<string,string> PhoneBook) {
            return Content($" {name}");

        }

        //test Cusotm Object
        //http://localhost:36786/bind/testobj?id=1&name=sd&Employees[0].name=alaa
        public IActionResult TestObj(Department dept)//1)create Object  =>Bind Public Proprty
        //public IActionResult TestObj(int Id,string Name, List<Employee> Employees)//1)create Object  =>Bind Public Proprty
        {
            return Content($"{dept.Name}");
        }
    }
}
