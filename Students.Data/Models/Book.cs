using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Book
    {
        public int Id { get; set; }
        public string title { get; set; }
        public int AvailableQuantity { get; set; }
        public string PublishedYear { get; set; }
        public int SubCategoryId { get; set; }
    }
}
