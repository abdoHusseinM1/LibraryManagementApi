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
                return BadRequest();
            }

            //POJO model = await _Student.Save(_student);

            _Category.Save(newCategory);

            return Ok("Saved");
        }

        //get by id 
        [HttpGet("{id}")]
        public IActionResult getCategory(int? id)
        {
            Category category = _Category.GetCategory(id);
            return Ok(category);
        }

        //get all categories
        [HttpGet]
        public IActionResult getAllCategories()
        {
            IQueryable<Category> categories = _Category.GetCategories();
            return Ok(categories);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCategory(int id)
        {
            _Category.Delete(id);
            return Ok("Category Deleted Succefully");
        }

        [HttpGet("getLength")]
        public IActionResult getLength()
        {
            int length = _Category.GetLength();
            return Ok(length);
        }
    }
}
