namespace Bookshop.API.Core.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Author")]
    public partial class Author
    {
        public int AuthorID { get; set; }

        [StringLength(255)]
        public string Firstname { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }
    }
}
