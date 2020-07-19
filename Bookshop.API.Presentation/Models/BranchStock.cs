using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Presentation.Models
{
    [DataContract(Name = "BranchStock")]
    public class BranchStock
    {
        [DataMember]
        public int BranchStockID { get; set; }

        [DataMember]
        public int BranchID { get; set; }

        [DataMember]
        public int BookID { get; set; }

        [DataMember]
        public int StockAmount { get; set; }

        [DataMember]
        public Book Book { get; set; }

    }
}
