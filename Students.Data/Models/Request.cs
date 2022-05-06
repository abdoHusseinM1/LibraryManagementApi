using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string  Status { get; set; }
        public string StudentName { get; set; }
        public string StudentId { get; set; }
        public int BookId { get; set; }

    }
}
