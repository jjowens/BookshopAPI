namespace Bookshop.API.Core.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BranchStock")]
    public partial class BranchStock
    {
        public int BranchStockID { get; set; }

        public int BranchID { get; set; }

        public int BookID { get; set; }

        public int StockAmount { get; set; }
    }
}
