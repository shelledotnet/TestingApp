using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Models;

namespace Test.API.ModelValidation
{
    public class Create_EnsureDeuDateIsFutureDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as CreateTicket;

            //if (ticket.Deudate.HasValue)
            //{
            //    var futureDate = (DateTime)ticket.Deudate;
            //    var dt = (futureDate.Date - DateTime.Now.Date).Days;
            //    if (dt <= 0)
            //        return new ValidationResult("Due date must be a future date");
            //}


            //when creating ticket , ticket due date has to be in the future
            if(ticket !=null && ticket.TicketId != null)
            {
                if(ticket.Deudate.HasValue && ticket.Deudate.Value < DateTime.Now)
                {
                    return new ValidationResult("Due date has to be in the future. ");
                }
            }
            return ValidationResult.Success;

        }
    }
}
