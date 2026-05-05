using DamWebAppApril.Models;
using System.ComponentModel.DataAnnotations;

namespace DamWebAppApril.ViewModel
{
    public class EmpWithDeptListViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Employe - NAme")] //parioty1 
        //[DataType(DataType.EmailAddress)]
        public string EmpName { get; set; } //periort y2 
        public string? ImageURl { get; set; }
        public int NetSalary { get; set; }
        public int DepartmentID { get; set; }
        public List<Department> DeptList { get; set; }
    }
}
