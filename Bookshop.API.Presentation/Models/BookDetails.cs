using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Bookshop.API.Presentation.Models
{
    [DataContract(Name = "Book")]
    public class BookDetails
    {
        [DataMember(Order = 1)]
        public int BookID { get; set; }

        [DataMember(Order = 2)]
        public Book Book { get; set; }

        [DataMember(Order = 3)]
        public IEnumerable<Author> Authors { get; set; }

        [DataMember(Order = 4)]
        public IEnumerable<Genre> Genres { get; set; }
    }
}