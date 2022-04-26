using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes
{
    public class CustomValidators
    {
        public class BirthDayAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                TimeSpan timeSpan = DateTime.Today.Subtract((DateTime)value);
                int age = (int)(timeSpan.TotalDays / 365);

                if (age < 18)
                {
                    return new ValidationResult("Chef must be 18 years or older.");
                }
                return ValidationResult.Success;
            }
        }
    }
}
