using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Extensions;
using Test.API.Filters;
using Test.API.Models;

namespace Test.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   // [Version1DiscontinueResourceFilter] we can add filter globally at the startup.cs
    public class TicketsController : ControllerBase
    {

        [HttpGet("projects/{pid}/tickect")]
        public IActionResult Post([FromQuery] TicketDto ticket)
        {
            if (ticket.TicketId == null)
                return BadRequest(new { code="400",description= "invalid request" });


            if (ticket.TicketId == 0)
                return Ok($"Reading all tickect belongs to project ");
            return Ok($"Reading project {ticket.ProjectId}, ticket {ticket.TicketId}");
        }


        [HttpPost()]
        public IActionResult PostForTicket([FromBody] CreateTicketDto ticket)
        {
            #region this is pass globally using actionfilter all the below modelsttate validato is now at the actionfiler
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetApiResponse()); 
            #endregion
            return Ok(ticket);
        }

        [HttpPost()]
        [Route("/api/v2/tickets")]
        [CreateTicketDto_ValidateDateActionFilter]  // this action filter only affect this action method
        public IActionResult PostForTicketv2([FromBody] CreateTicketDto ticket)
        {
            
            #region this is pass globally using actionfilter all the below modelsttate validato is now at the actionfiler
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetApiResponse()); 
            #endregion
            return Ok(ticket);
        }
    }
}
