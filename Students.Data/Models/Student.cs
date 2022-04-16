using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string NationalId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsAccepted { get; set; } 


    }
}
