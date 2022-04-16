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

        public string FullName { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; } = false;
        public bool accepted { get; set; } = false;
    }
}
