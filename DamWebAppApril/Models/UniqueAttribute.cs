using System.ComponentModel.DataAnnotations;

namespace DamWebAppApril.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
     
        //not support inject inn constructor
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ITIContext context = 
                validationContext.GetRequiredService<ITIContext>();//ask service provider not create ;
            
            string name = value.ToString();
            //unique per100 department from req
            Employee? empFromRequest = validationContext.ObjectInstance as Employee;

            Employee? empFromDatabase= context.Employees
                .FirstOrDefault(e => e.Name == name && e.DepartmentID==empFromRequest.DepartmentID);

            if(empFromDatabase == null) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name Already Exist in Selected Department :(");
        }
    }
}
