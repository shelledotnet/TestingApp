using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Test.API.ModelValidation;

namespace Test.API.Models
{
    public class Ticket
    {
        [FromHeader(Name = "clientId")]
        public Guid ClientId { get; set; }

        [FromQuery(Name ="tid")]
       
        public int? TicketId { get; set; }

        [FromRoute(Name = "pid")]
        public int? ProjectId { get; set; }

        // [Required]
        //public string Title { get; set; }
        //public string Description { get; set; }

        //public string Owner { get; set; }
        //public DateTime? Deudate { get; set; }
    }
    public class CreateTicket
    {
        public int? TicketId { get; set; }
        [Required(ErrorMessage ="invalid value pass for project id")]
        public int? ProjectId { get; set; }

        [Required(ErrorMessage ="invalid value pass for title")]
        public string Title { get; set; }
        public string Description { get; set; }

        #region Owner must have a deudate their is custome validation attribute
        public string Owner { get; set; }

        //custom validation attribute
        [CreateTicket_EnsureDeuDateForTicketOwner]
        [Create_EnsureDeuDateIsFutureDate]
        public DateTime? Deudate { get; set; } 
        #endregion
    }
}
