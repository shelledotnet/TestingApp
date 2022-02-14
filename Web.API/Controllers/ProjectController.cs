using Core.DataStore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly BugsContext _db;

        public ProjectController(BugsContext db)
        {
            this._db = db;
        }
        // GET: api/<ProjectController>
        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(new { code = "00", description = "success", data = _db.Project.ToList() });

        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //we use find clause because its a primary key
            var proj = _db.Project.Find(id);
            if (proj is null)
              return NotFound(new { code = "99", description = "failed", data = $"id {id} is not in th project " });
            return Ok(new { code = "00", description = "success", data = proj });
        }

        [HttpGet("/{pid}/tickect")]
        public IActionResult GetTicketById(int id)
        {
            //becos project id is foreign we cant use find but where clause
           var ticket= _db.Ticket.Where(x => x.ProjectId == id).ToList();

            //for a list it will always hav record even if d query is null ..there4 its good practist to check on the count of records
            if (ticket is null || ticket.Count <=0)
                return NotFound(new { code = "99", description = "failed", data = $"id {id} has no ticket " });
            return Ok(new { code = "00", description = "success", data = ticket });
        }






        // POST api/<ProjectController>
        //[HttpPost]
        //public void Post([FromBody])
        //{
        //}

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
