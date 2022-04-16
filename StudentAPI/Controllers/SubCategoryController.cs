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
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategory _SubCategory;

        //constructor
        public SubCategoryController(ISubCategory d)
        {
            _SubCategory = d;
        }



        // 1 - GetSubCategories(int? MainCategoryId);

        [HttpGet("getSubCategories")]
        public IActionResult GetSubCategories(int? MainCategoryId)
        {
            IQueryable<SubCategory> s = _SubCategory.GetSubCategories(MainCategoryId);
            return Ok(s);
        }

        // 2 - Save(SubCategory subCategory);

        [HttpPost("add-new-subCategory")]
        public IActionResult Save([FromBody] SubCategory subCategory)
        {
            if(subCategory == null)
            {
                return BadRequest("Request wasn't sent duo to null Data");
            }

            _SubCategory.Save(subCategory);
            return Ok("Saved");
        }

        // 3 - Delete(int? id);
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            _SubCategory.Delete(id);
            return Ok("Deleted");
        }

        // 4 - ChangeMainCategory(int? SubCategoryId, int NewMainCategoryId);
        [HttpPut("change-main-category")]
        public IActionResult ChangeMainCategory(int? SubCategoryId , int NewCategoryId)
        {
            _SubCategory.ChangeMainCategory(SubCategoryId, NewCategoryId);
            return Ok("Saved");
        }

        // 5 - getlength(int? MainCategoryId);
        [HttpGet("get-length/{MainCategoryId}")]
        public IActionResult GetLength(int MainCategoryId)
        {
            return Ok(_SubCategory.getlength(MainCategoryId));
            
        }
        // 6 - getSubCategory
        [HttpGet("{id}")]
        public IActionResult GetSubCategory(int? id)
        {
            SubCategory subCategory = _SubCategory.GetSubCatgory(id);
            return Ok(subCategory);
        }

    }


}
