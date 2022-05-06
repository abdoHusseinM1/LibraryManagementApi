using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Category name is required")]
        [StringLength(100)]
        public string CategoryName { get; set; }

    }
}
