using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bookshop.API.Presentation.ServiceModels;
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
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<Book, BookDetailsDTO>()
                .ForMember(a => a.Book, b => b.MapFrom(bk => bk));
                cfg.CreateMap<Author, AuthorDTO>();
                cfg.CreateMap<Genre, GenreDTO>();
                cfg.CreateMap<BookGenre, BookGenreDTO>();
                cfg.CreateMap<BookAuthor, BookAuthorDTO>();
            });

            this.mapper = new Mapper(config);
        }

        public Mapper mapper { get; set; }
    }
}
