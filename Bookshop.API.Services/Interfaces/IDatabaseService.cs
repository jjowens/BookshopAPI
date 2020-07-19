using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.API.Core.DB;

namespace Bookshop.API.Services.Interfaces
{
    public interface IDatabaseService
    {
        BookshopAPIDB dbContext { get; set; }

    }
}
