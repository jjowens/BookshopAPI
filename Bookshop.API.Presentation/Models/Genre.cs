using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Bookshop.API.Presentation.Models
{
    [DataContract]
    public class Genre
    {
        [DataMember]
        public int GenreID { get; set; }

        [DataMember]
        public string GenreName { get; set; }
    }
}