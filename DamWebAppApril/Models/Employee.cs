using System.ComponentModel.DataAnnotations.Schema;

namespace DamWebAppApril.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageURl { get; set; }
        public int Salary { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
