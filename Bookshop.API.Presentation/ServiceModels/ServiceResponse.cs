using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Presentation.ServiceModels
{
    public class ServiceResponse
    {
        public int ID { get; set; }
        public bool IsError { get; set; }
        public string LogMessage { get; set; }
        public Exception exception { get; set; }
    }
}
