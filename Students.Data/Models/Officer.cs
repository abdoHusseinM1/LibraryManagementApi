using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Data
{
    public class Officer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }
        [MinLength(14)]
        [MaxLength(14)]
        public string NationalId { get; set; }
        public string Address { get; set; }
        [EmailAddress(ErrorMessage ="Email address is Invalid")]
        public string Email { get; set; }
        [MinLength(8)]
        public string Password { get; set; }

        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
        [DefaultValue(false)]
        public bool IsBlocked { get; set; } = false;
        [DefaultValue(false)]
        public bool IsAccepted { get; set; } = false;
    }
}
