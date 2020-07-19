namespace Bookshop.API.Core.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BranchSoldStock")]
    public partial class BranchSoldStock
    {
        public int BranchSoldStockID { get; set; }

        public int BranchID { get; set; }

        public int BookID { get; set; }

        public int StockSold { get; set; }

        public decimal? StockTotalPrice { get; set; }

        public DateTime SoldDateTime { get; set; }
    }
}
