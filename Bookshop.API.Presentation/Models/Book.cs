using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Bookshop.API.Presentation.Models
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int BookID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Subtitle { get; set; }

        [DataMember]
        public int? PublishYear { get; set; }

        [DataMember]
        public decimal? Price { get; set; }
    }
}
