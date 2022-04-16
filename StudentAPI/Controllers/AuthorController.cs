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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthor _Author;

        public AuthorController(IAuthor author)
        {
            _Author = author;
        }

        [HttpPost]
        public IActionResult Save([FromBody]Author NewAuthor)
        {
            if(NewAuthor == null)
            {
                return BadRequest("The Author Is Null");
            }

            _Author.Save(NewAuthor);
            return Ok("Author Saved");
        }

        // get by Id
        [HttpGet("{id}")]
        public IActionResult GetAuthor(int? id)
        {
            Author author = _Author.GetAuthor(id);
            return Ok(author);
        }

        //get all authors
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            IQueryable AllAuthors = _Author.GetAuthors();
            return Ok(AllAuthors);
        }

        // delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            _Author.Delete(id);
            return Ok("author deleted");
        }

        // get length
        [HttpGet("length")]
        public IActionResult GetLength()
        {
            int length = _Author.GetLength();
            return Ok(length);
        }




        
    }
}
