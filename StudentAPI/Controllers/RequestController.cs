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

        // 4 IQueryable GetRequests();
        [HttpGet]
        public IActionResult GetRequests()
        {
            IQueryable queryable = _Request.GetRequests();
            return Ok(queryable);
        }

        // 5 List<Request> GetRequestsByStudentNationalId(string NationalId);
        [HttpGet("get-request-by-national-id")]
        public IActionResult GetRequestsByStudentNationalId( string NationalId)
        {
            List<Request> list = _Request.GetRequestsByStudentNationalId(NationalId);
            return Ok(list);
        }

        // 6 void ChangeRequesStatus(int? Id, string NewStatus);
        [HttpPut("change-request-status/{id}")]
        public IActionResult ChangeRequestStatus(int Id, string NewStatus)
        {
            _Request.ChangeRequesStatus(Id, NewStatus);
            return Ok("Status Changed Successfully");
        }

    }
}
