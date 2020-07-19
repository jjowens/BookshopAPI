using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.API.Services.Interfaces
{
    public interface IMapperService
    {
        Mapper mapper { get; set; }
    }
}
