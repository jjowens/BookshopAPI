using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Presentation.Models
{
    [DataContract()]
    public class BranchStockDetails
    {
        [DataMember]
        public Branch Branch { get; set; }

        [DataMember]
        public IEnumerable<BranchStock> BranchStock { get; set; }

    }
}
