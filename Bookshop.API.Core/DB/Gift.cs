namespace Bookshop.API.Core.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gift")]
    public partial class Gift
    {
        public int GiftID { get; set; }

        [Required]
        [StringLength(255)]
        public string GiftName { get; set; }

        public decimal? GiftPrice { get; set; }
    }
}
