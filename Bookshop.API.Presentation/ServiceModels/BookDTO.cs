using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Presentation.ServiceModels
{
    public class BookDTO
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int PublishedYear { get; set; }

    }
}
