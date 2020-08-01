using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bookshop.API.Services.Interfaces;
using Bookshop.API.Core.DB;

namespace Bookshop.API.Services.Services
{
    public class MapperService : IMapperService
    {
        public MapperService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Book, Presentation.ServiceModels.Book>();
                cfg.CreateMap<Presentation.ServiceModels.Book, Book>();
                cfg.CreateMap<Book, Presentation.ServiceModels.BookDetails>()
                .ForMember(a => a.Book, b => b.MapFrom(bk => bk));
                cfg.CreateMap<Author, Presentation.ServiceModels.Author>();
                cfg.CreateMap<Genre, Presentation.ServiceModels.Genre>();
                cfg.CreateMap<BookGenre, Presentation.ServiceModels.BookGenre>();
                cfg.CreateMap<BookAuthor, Presentation.ServiceModels.BookAuthor>();
                cfg.CreateMap<Genre, Presentation.ServiceModels.Genre>();
            });

            this.mapper = new Mapper(config);
        }

        public Mapper mapper { get; set; }
    }
}
