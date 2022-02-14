using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Models;

namespace Test.API.ModelValidation
{
    public class CreateTicketDto_EnsureDeuDateAndFutureDateForTicketOwnerAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as CreateTicketDto;
            //when creating ticket , ticket needs an owner
            if (ticket != null && !string.IsNullOrWhiteSpace(ticket.Owner))
            {
                if (!ticket.Deudate.HasValue)
                    return new ValidationResult("Due date is required when a ticket has an owner");


            }
            //when creating ticket , ticket due date has to be in the future
            if (ticket != null && ticket.TicketId != null)
            {
                if (ticket.Deudate.HasValue && ticket.Deudate < DateTime.Now)
                {
                    return new ValidationResult("Due date has to be in the future. ");
                }
            }
            return ValidationResult.Success;
        }
    }
    public class CreateTicketDto_EnsureTickeIdForTicketOwnerAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as CreateTicketDto;
            //when creating ticket , ticket is required
            if (ticket != null && ticket.TicketId.HasValue==false)
                return new ValidationResult("ticket id is required for owner");

            return ValidationResult.Success;
        }
    }
}
