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
    
    public class BookController : ControllerBase
    {
        private readonly IBook _Book;

        //constructor
        public BookController(IBook b)
        {
            _Book = b;
        }

        // 1 - void Delete(int? id);

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _Book.Delete(id);
            return Ok("Book Deleted");
        }

        // 2 - void SaveBook(Book book);
        [HttpPost]
        public IActionResult SaveBook([FromBody]Book book)
        {
            if(book == null)
            {
                return BadRequest("null data sent");
            }else
            {
                _Book.SaveBook(book);
                return Ok("Saved");
            }

        }
        // 3 - int GetLength();
        [HttpGet("get-length")]
        public IActionResult GetLength()
        {
            return Ok(_Book.GetLength());
        }
        // 4 - int GetSubCategoryId(int bookId);
        [HttpGet("get-sub-category")]
        public IActionResult GetSubCategoryId(int Id)
        {
            return Ok(_Book.GetSubCategoryId(Id));
        }

        // 5 - IQueryable GetAllBooks();
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_Book.GetAllBooks());
        }

        // 6 - IQueryable GetBooksFromSubCategory(int subCategoryId);
        [HttpGet("get-books-from-sub-category-id")]
        public IActionResult GetBooksFromSubCategory(int Id)
        {
            return Ok(_Book.GetBooksFromSubCategory(Id));
        }
    }
}
