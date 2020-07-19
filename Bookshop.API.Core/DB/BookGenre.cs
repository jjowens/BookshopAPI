namespace Bookshop.API.Core.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookGenre")]
    public partial class BookGenre
    {
        public int BookGenreID { get; set; }

        public int GenreID { get; set; }

        public int BookID { get; set; }
    }
}
