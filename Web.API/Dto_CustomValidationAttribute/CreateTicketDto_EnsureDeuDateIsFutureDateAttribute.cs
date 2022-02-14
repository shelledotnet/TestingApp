using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Models;

namespace Test.API.ModelValidation
{
    public class CreateTicketDto_EnsureDeuDateIsFutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as CreateTicketDto;

            //if (ticket.Deudate.HasValue)
            //{
            //    var futureDate = (DateTime)ticket.Deudate;
            //    var dt = (futureDate.Date - DateTime.Now.Date).Days;
            //    if (dt <= 0)
            //        return new ValidationResult("Due date must be a future date");
            //}


           
            return ValidationResult.Success;

        }
    }
}
