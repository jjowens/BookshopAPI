namespace Bookshop.API.Core.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookEvent")]
    public partial class BookEvent
    {
        public int BookEventID { get; set; }

        [Required]
        [StringLength(255)]
        public string BookEventName { get; set; }

        public DateTime? BookEventDate { get; set; }
    }
}
