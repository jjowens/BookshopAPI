using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Presentation.Models
{
    [DataContract(Name = "Branch")]
    public class Branch
    {
        [DataMember]
        public int BranchID { get; set; }

        [DataMember]
        public string BranchName { get; set; }

        [DataMember]
        public string Address1 { get; set; }

        [DataMember]
        public string Address2 { get; set; }

        [DataMember]
        public int TownCityID { get; set; }

        [DataMember]
        public int CountryID { get; set; }

        [DataMember]
        public string TownCity { get; set; }

        [DataMember]
        public string Country { get; set; }

    }
}
