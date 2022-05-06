using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage ="Email is reqiured argument")]
        [MaxLength(120 , ErrorMessage = "Max length is 120")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email is reqiured argument")]
        [MinLength(8 , ErrorMessage = "Minimum Length is 8")]
        public string Password { get; set; }
    }
}
