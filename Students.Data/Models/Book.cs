using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Book title is required")]
        public string Title { get; set; }
        public int AvailableQuantity { get; set; }
        [Range(1000 , 2100)]
        public int PublishedYear { get; set; }
        public int SubCategoryId { get; set; }
    }
}
