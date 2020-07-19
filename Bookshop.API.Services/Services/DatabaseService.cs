using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.API.Core.DB;
using Bookshop.API.Presentation.ServiceModels;
using Bookshop.API.Services.Interfaces;

namespace Bookshop.API.Services.Services
{
    public class DatabaseService : IDatabaseService
    {
        public DatabaseService()
        {
            dbContext = new BookshopAPIDB();
        }

        public BookshopAPIDB dbContext { get; set; }
    }
}
