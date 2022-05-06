using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(120 , ErrorMessage ="Author Name is too long")]
        public string AuthorName { get; set; }
    }
}
