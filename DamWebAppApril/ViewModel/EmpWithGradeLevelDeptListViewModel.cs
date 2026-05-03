using DamWebAppApril.Models;

namespace DamWebAppApril.ViewModel
{
    public class EmpWithGradeLevelDeptListViewModel
    {
        //Send some Model Property +hide Colun name
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        //Megre with another model
        public List<Department> DeptList { get; set; }
        //Extar info
        public string Level { get; set; }
        public int Grade { get; set; }
        public string Color { get; set; }
    }
}
