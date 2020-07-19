﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Bookshop.API.Presentation.Models
{
    [DataContract]
    public class Author
    {
        [DataMember]
        public int AuthorID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }

    }
}