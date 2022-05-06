using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repos_Interfaces;
using Services;
using Students.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILogin _Login;
        IStudent _Student;
        IOfficer _Offcer;
        public LoginController(ILogin l)
        {
            this._Login = l;
        }

        [HttpPost("login-student")]
        public IActionResult LoginStudent([FromBody] LoginUser user)
        {
            if(user == null)
            {
                return BadRequest("Null Object");
            }
            int result = _Login.LoginStudent(user);
            if (result != 0)
            {
                return BadRequest("Invalid Login");
            }
            var student = _Student.GetStudentByEmail(user.Email);
            return Ok(student);
        }

        [HttpPost("login-officer")]
        public IActionResult LoginOfficer([FromBody] LoginUser user)
        {
            if (user == null)
            {
                return BadRequest("Null Object");
            }
            int result = _Login.LoginOfficer(user);
            if (result != 0)
            {
                return BadRequest("Invalid Credentials");
            }
            var officer = _Offcer.GetOfficerByEmail(user.Email);
            return Ok(officer);
        }
    }
}
