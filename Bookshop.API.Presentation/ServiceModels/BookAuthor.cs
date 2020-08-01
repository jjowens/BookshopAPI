using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Presentation.ServiceModels
{
    public class BookAuthor
    {
        public int BookAuthorID { get; set; }
        public int BookID { get; set; }
        public int AuthorID { get; set; }
    }
}
