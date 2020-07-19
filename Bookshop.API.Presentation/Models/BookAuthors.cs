using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookshop.API.Presentation.Models
{
    public class BookAuthors
    {

        public int ID { get; set; }

        public int BookID { get; set; }
        public int AuthorID { get; set; }
    }
}