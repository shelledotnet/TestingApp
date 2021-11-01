using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Extensions;
using Test.API.Models;

namespace Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        [HttpGet("projects/{pid}/tickect")]
        public IActionResult Post([FromQuery] Ticket ticket)
        {
            if (ticket.TicketId == null)
                return BadRequest(new { code="400",description= "invalid request" });


            if (ticket.TicketId == 0)
                return Ok($"Reading all tickect belongs to project ");
            return Ok($"Reading project {ticket.ProjectId}, ticket {ticket.TicketId}");
        }


        [HttpPost("winners")]
        public IActionResult PostForTicket([FromBody] CreateTicket ticket)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetApiResponse());
            return Ok(ticket);
        }
    }
}
