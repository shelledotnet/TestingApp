using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Models;

namespace Test.API.ModelValidation
{
    public class CreateTicket_EnsureDeuDateForTicketOwnerAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as CreateTicket;
            if (ticket != null && !string.IsNullOrWhiteSpace(ticket.Owner))
            {
                if (!ticket.Deudate.HasValue)
                    return new ValidationResult("Due date is required when a ticket has an owner");


            }
            return ValidationResult.Success;
        }
    }
}
