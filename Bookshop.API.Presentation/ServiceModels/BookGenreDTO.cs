using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Presentation.ServiceModels
{
    public class BookGenreDTO
    {
        public int BookGenreID { get; set; }
        public int GenreID { get; set; }
        public int BookID { get; set; }
    }
}
