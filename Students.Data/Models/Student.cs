using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Full Name is required")]
        public string FullName { get; set; }
        public string Address { get; set; }
        [StringLength(11 , ErrorMessage = "The Phone Number isn't Correct , It Should be 11 number")]
        [Phone(ErrorMessage = "Invalid Phone")]
        public string Phone { get; set; }
        [StringLength(14 , ErrorMessage ="Invalid National Id")]
        public string NationalId { get; set; }

        [MinLength(8, ErrorMessage = "Minimum Length is 8")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is reqiured argument")]
        [MaxLength(120, ErrorMessage = "Max length is 120")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [DefaultValue(false)]
        public bool IsBlocked { get; set; }
        [DefaultValue(false)]
        public bool IsAccepted { get; set; } 


    }
}
