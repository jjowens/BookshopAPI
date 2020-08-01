using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bookshop.API.Presentation.ServiceModels;
using Bookshop.API.Services.Services;
using Bookshop.API.Services.Interfaces;

namespace Bookshop.API.Controllers
{
    [RoutePrefix("api/bookshop")]
    public class BookshopController : ApiController
    {

        public BookshopController()
        {
            _dbService = new DatabaseService();
            _mapService = new MapperService();
            _bookshopService = new BookshopService(_dbService, _mapService);
        }

        IDatabaseService _dbService;
        IMapperService _mapService;
        IBookshopService _bookshopService;


        [HttpGet]
        [Route("checkstatus")]
        public string CheckStatus()
        {
            return string.Format("Status: API is running. {0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
        }

        [HttpGet]
        [Route("genres")]
        public IEnumerable<Genre> GetGenres()
        {
            var listOfGenres = _bookshopService.GetGenres();

            return listOfGenres;
        }

        [HttpGet]
        [Route("authors")]
        public IEnumerable<Author> GetAuthors()
        {
            var listOfAuthors = _bookshopService.GetAllAuthors();

            return listOfAuthors;
        }

        [HttpGet]
        [Route("books")]
        public IEnumerable<BookDetails> GetBooks()
        {
            var listOfBooks = _bookshopService.GetAllBooks(0);

            return listOfBooks;
        }

        [HttpPost]
        [Route("books/save")]
        public APIResponse SaveBooks(BookDetails bookDetails)
        {
            APIResponse apiResponse = new APIResponse();

            var response = _bookshopService.SaveBookDetails(bookDetails);

            apiResponse.ID = response.ID;
            apiResponse.HasErrors = response.ContainErrors;
            apiResponse.LogMessage = response.LogMessage;

            return apiResponse;
        }

        [HttpPost]
        [Route("books/book/delete")]
        public APIResponse DeleteBook([FromBody]int bookID)
        {
            APIResponse apiResponse = new APIResponse();

            var response = _bookshopService.DeleteBook(bookID);

            apiResponse.ID = response.ID;
            apiResponse.HasErrors = response.ContainErrors;
            apiResponse.LogMessage = response.LogMessage;

            return apiResponse;
        }

        [HttpPost]
        [Route("books/author/delete")]
        public APIResponse DeleteAuthor([FromBody]int authorID)
        {
            APIResponse apiResponse = new APIResponse();

            var response = _bookshopService.DeleteAuthor(authorID);

            apiResponse.ID = response.ID;
            apiResponse.HasErrors = response.ContainErrors;
            apiResponse.LogMessage = response.LogMessage;

            return apiResponse;
        }

        [HttpPost]
        [Route("books/search")]
        public IEnumerable<BookDetails> SearchBooks(Search search)
        {
            APIResponse apiResponse = new APIResponse();

            var response = _bookshopService.SearchBooks(search);

            return response;
        }


    }
}
