using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Presentation.ServiceModels
{
    public class BookDetailsDTO
    {
        public BookDTO Book { get; set; }
        public IEnumerable<AuthorDTO> Authors { get; set; }
        public IEnumerable<GenreDTO> Genres { get; set; }

    }
}
