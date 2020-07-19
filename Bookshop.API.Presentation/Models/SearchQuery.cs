using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Presentation.Models
{
    public class SearchQuery
    {
        public string Title { get; set; }

        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public string[] Genres { get; set; }
        
    }
}
