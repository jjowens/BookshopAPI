using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Presentation.ServiceModels
{
    public class APIResponse
    {
        public int ID { get; set; }
        public string LogMessage { get; set; }
        public bool HasErrors { get; set; }

    }
}
