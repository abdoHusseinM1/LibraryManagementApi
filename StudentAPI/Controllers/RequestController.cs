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
    public class RequestController : ControllerBase
    {
        private readonly IRequest _Request;

        public RequestController(IRequest dp)
        {
            _Request = dp;
        }

        // 1 void DeleteRequest(int? Id);

        [HttpDelete("{id}")]
        public IActionResult DeleteRequest(int Id)
        {
            _Request.DeleteRequest(Id);
            return Ok("Request Delted");
        }

        // 2 void Save(Request request);
        [HttpPost]
        public IActionResult AddRequest([FromBody] Request request)
        {
            return Ok(_Request.Save(request));
        }
        // 3 int GetLength();
        [HttpGet("get-length")]
        public IActionResult Getlength()
        {
            int length = _Request.GetLength();
            return Ok(length);
        }

        // 4 list GetRequests();
        [HttpGet]
        public IActionResult GetRequests()
        {
            List<Request> list = _Request.GetRequests();
            return Ok(list);
        }

        // 5 List<Request> GetRequestsByStudentNationalId(string NationalId);
        [HttpGet("get-request-by-national-id/{NationalId}")]
        public IActionResult GetRequestsByStudentNationalId(string NationalId)
        {
            List<Request> list = _Request.GetRequestsByStudentNationalId(NationalId);
            if (list.Count == 0)
                return BadRequest("Un matched");

            return Ok(list);
        }

        // return a book

        [HttpPut("return-book/{id}")]
        public IActionResult ReturnBook (int id)
        {
            if(_Request.getRequest(id) == null)
            {
                return BadRequest("invalid id");
            }

            _Request.ReturnBook(id);
            return Ok("book returned");
        }

        [HttpPut("cancel-request/{id}")]
        public IActionResult CancelRequest(int id)
        {
            if(_Request.getRequest(id) == null)
            {
                return BadRequest("Invalid id");
            }

            _Request.CancelRequest(id);
            return Ok("Request Canceled");
        }

        //refresh status 
        [HttpGet("refresh-status")]
        public IActionResult RefreshStatus()
        {
            _Request.RefreshStatus();
            return Ok("done");
        }

        //get 1 request
        [HttpGet("{id}")]
        public IActionResult GetRequest(int? id)
        {
            Request r = _Request.getRequest(id);
            if (r == null)
                return BadRequest("invalid id");

            return Ok(r);
        }
    }

    
}
