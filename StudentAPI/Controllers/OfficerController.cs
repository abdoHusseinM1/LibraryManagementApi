using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficerController : ControllerBase
    {

        private readonly IOfficer _officer;

        //  constructor 
        public OfficerController (IOfficer officer)
        {
            _officer = officer;
        }

        // 1 - get all officers
        [HttpGet]
        public IActionResult GetOfficers()
        {
            IQueryable officers = _officer.GetOfficers;
            return Ok(officers);
        }

        // 2 - accept officer
        [HttpPut("accept-officer/{id}")]
        public IActionResult AcceptOfficer(int? Id)
        {
            _officer.AcceptOfficer(Id);
            return Ok("Offcer Accepted");
        }

        // 3 - block officer
        [HttpPut("block-officer/{id}")]
        public IActionResult BlockOfficer(int? id)
        {
            _officer.BlockOfficer(id);
            return Ok("Officer Blocked");
        }
        // 4 - delete officer
        [HttpDelete("{id}")]
        public IActionResult DeleteOfficer(int? id)
        {
            _officer.Delete(id);
            return Ok("Officer Deleted");
        }

        // 5 - number of officers
        [HttpGet("get-length")]
        public IActionResult GetLength()
        {
            return Ok(_officer.getLength());
        }

        // 6 - get an officer
        [HttpGet("{id}")]
        public IActionResult GetOfficer(int? id)
        {
            Officer _entity = _officer.GetOfficer(id);
            return Ok(_entity);
        }
        // 7 - add and update
        [HttpPost]
        public IActionResult Save([FromBody] Officer officer)
        {
            if(officer == null)
            {
                return BadRequest("null body");
            }

            _officer.Save(officer);
            return Ok("Saved");
        }

        // 8 - make admin
        [HttpPut("make-admin/{id}")]
        public IActionResult MakeAdmin(int? id)
        {
            _officer.MakeAdmin(id);
            return Ok("Made admin");
        }


    }
}
