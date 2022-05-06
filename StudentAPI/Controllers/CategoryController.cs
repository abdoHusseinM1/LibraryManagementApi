using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _Category;

        //constructor
        public CategoryController(ICategory _dp)
        {
            _Category = _dp;
        }

        //save 
        [HttpPost]
        public IActionResult Save([FromBody] Category newCategory)
        {
            if (newCategory == null)
            {
                return BadRequest("Null Data");
            }

            _Category.Save(newCategory);

            return Ok("Saved");
        }

        //get by id 
        [HttpGet("{id}")]
        public IActionResult getCategory(int? id)
        {
            //Dictionary<string, dynamic> d = new Dictionary<string, dynamic>();
            
            Category category = _Category.GetCategory(id);
            if(category == null)
            {
                return BadRequest("Invalid Id");
            }
            //d.Add("category", category);
            //d.Add("subCategories", 10);

            return Ok(category);
        }

        //get all categories
        [HttpGet]
        public IActionResult getAllCategories()
        {
            List<Category> categories = _Category.GetCategories();
            return Ok(categories);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCategory(int id)
        {
            Category c = _Category.GetCategory(id);
            if(c == null)
            {
                return BadRequest("Invalid Id");
            }

            _Category.Delete(id);
            return Ok("Category Deleted");
        }

        [HttpGet("getLength")]
        public IActionResult getLength()
        {
            int length = _Category.GetLength();
            return Ok(length);
        }

        [HttpGet("get-books-length/{id}")]
        public IActionResult getBooksLength(int id)
        {
            int a = _Category.GetBooksLength(id);
            return Ok(a);
        }
    
        
    }
}
