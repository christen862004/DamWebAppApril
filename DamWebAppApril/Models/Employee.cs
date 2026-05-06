using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DamWebAppApril.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name Required")]
        [StringLength(50,MinimumLength =3)]
        [Unique]//server side only
        public string Name { get; set; }
        
        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must be png or jpg ex: img.png")]//ahnmed.jpg
        public string? ImageURl { get; set; }

        //[Range(7000,50000)]
        // [Required]
        //[MoreThan(7000)]
        [Remote("CheckSalary","Employee",AdditionalFields = "DepartmentID")]//Employee/CheckSalary?Salary=100&DepartmentID=9
        public int Salary { get; set; }
        
        [ForeignKey("Department")]
        // [Required]
        public int DepartmentID { get; set; }
        // [Required]
        public Department? Department { get; set; }
    }
}
