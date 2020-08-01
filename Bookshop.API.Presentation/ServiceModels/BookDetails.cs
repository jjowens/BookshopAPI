using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Presentation.ServiceModels
{
    [DataContract]
    public class BookDetails
    {
        [DataMember( Order = 0)]
        public Book Book { get; set; }
        [DataMember(Order = 1)]
        public IEnumerable<Author> Authors { get; set; }
        [DataMember(Order = 2)]
        public IEnumerable<Genre> Genres { get; set; }

    }
}
