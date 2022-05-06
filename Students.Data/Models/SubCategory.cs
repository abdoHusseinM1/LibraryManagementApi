using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SubCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sub-Category name is reqiured")]
        public string Name { get; set; }
        public int MainCategoryId { get; set; }

    }
}
