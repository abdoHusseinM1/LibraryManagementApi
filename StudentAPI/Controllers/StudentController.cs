using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Data;
using Students.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudent _Student;

        //controller constructor
        public StudentController(IStudent _dp)
        {
            _Student = _dp;
        }

        //save 
        [HttpPost]
        public IActionResult Save([FromBody] Student _student)
        {
            if (_student == null)
            {
                return BadRequest();
            }

            //POJO model = await _Student.Save(_student);

            _Student.Save(_student);

            return Ok("Saved");
        }

        //get one student
        [HttpGet("{Id}")]
        public IActionResult GetStudent(int? Id)
        {
            Student data = _Student.GetStudent(Id);
            return Ok(data);
        }

        //get all students
        [HttpGet]
        public IActionResult GetStudents()
        {
            IQueryable<Student> students = _Student.GetStudents;
            return Ok(students);
        }

        // delete student
        [HttpDelete("{Id}")]
        public IActionResult DeleteStudent(int? Id)
        {
            _Student.Delete(Id);
            return Ok("deleted successfully");
        }

        // the number of students
        [HttpGet("getLength")]
        public IActionResult getLength()
        {
            int length = _Student.getLength();
            return Ok(length);
        }

        // block student
        [HttpPut("block-student/{id}")]
        public IActionResult blockStudent(int? id)
        {
            _Student.BlockStudent(id);
            return Ok("Student Blocked");
        }

        //accept student
        [HttpPut("accept-student/{id}")]
        public IActionResult acceptSudent(int? id)
        {
            _Student.AcceptStudent(id);
            return Ok("Student Accepted");
        }
    }
}
