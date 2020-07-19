namespace Bookshop.API.Core.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookAuthor")]
    public partial class BookAuthor
    {
        public int BookAuthorID { get; set; }

        public int BookID { get; set; }

        public int AuthorID { get; set; }
    }
}
