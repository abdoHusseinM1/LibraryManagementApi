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
            }

            int result = _Book.SaveBook(book);
            if(result != 0)
            {
                return BadRequest("Already exists");
            }
            return Ok("Saved");

        }

        // 3 - int GetLength();
        [HttpGet("get-length")]
        public IActionResult GetLength()
        {
            return Ok(_Book.GetLength());
        }


        // 4 - int GetSubCategoryId(int bookId);
        [HttpGet("get-sub-category/{id}")]
        public IActionResult GetSubCategory(int id)
        {
            var subCategory = _Book.GetSubCategory(id);
            return Ok(subCategory);
        }

        // 5 - IQueryable GetAllBooks();
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            List<Book> books = _Book.GetAllBooks();
            return Ok(books);
        }

        // 6 - list GetBooksFromSubCategory(int subCategoryId);
        [HttpGet("get-books-from-sub-category-id")]
        public IActionResult GetBooksFromSubCategory(int id)
        {
            List<Book> books = _Book.GetBooksFromSubCategory(id);

            return Ok(books);

        }

        // 7 - getBook (int id)
        [HttpGet("{id}")]
        public IActionResult GetBook(int? id)
        {
            var book = _Book.GetBook(id);
            if (book == null)
            {
                return BadRequest("Invalid Id");
            }

            return Ok(book);
        }
    }
}

