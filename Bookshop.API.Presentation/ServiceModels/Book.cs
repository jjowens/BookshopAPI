using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Presentation.ServiceModels
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int PublishYear { get; set; }
        public double Price { get; set; }
        public string Subtitle { get; set; }

    }
}
