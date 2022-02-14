using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.API.Models
{
    public class TicketDto
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
}
