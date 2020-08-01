using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Presentation.ServiceModels
{
    public class Search
    {
        public int BookID { get; set; }
        public int AuthorID { get; set; }
        public string BookTitle { get; set; }
        public string[] Genres { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Year { get; set; }
    }
}
