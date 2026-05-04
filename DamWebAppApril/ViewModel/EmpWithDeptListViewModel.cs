using DamWebAppApril.Models;

namespace DamWebAppApril.ViewModel
{
    public class EmpWithDeptListViewModel
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string? ImageURl { get; set; }
        public int NetSalary { get; set; }
        public int DepartmentID { get; set; }
        public List<Department> DeptList { get; set; }
    }
}
