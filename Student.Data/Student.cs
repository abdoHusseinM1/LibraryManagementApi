using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Data
{
    public class Student
    {
        public int Id{ get; set; }
        public string FullName{ get; set; }
        public string NationalId{ get; set; }
        public string email{ get; set; }
        public string password { get; set; }
        public string adress { get; set; }
        public bool IsBlocked { get; set; }
        public string Phone { get; set; }

    }
}
