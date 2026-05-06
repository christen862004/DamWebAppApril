using System.ComponentModel.DataAnnotations;

namespace DamWebAppApril.Models
{
    public class MoreThanAttribute:ValidationAttribute
    {
        public MoreThanAttribute(int min)
        {
            Min = min;
        }
        public int Min { get; set; } = 0;
        public override bool IsValid(object? value)
        {
            int salary = int.Parse(value.ToString());
            if (salary > Min)
            {
                return true;
            }
            return false;
        }
        //protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        //{
        //    int salary = int.Parse(value.ToString());
        //    if (salary > Min)
        //    {
        //        return ValidationResult.Success;
        //    }
        //    return new ValidationResult("Salary More Than 7000");
        //}
    }
}
