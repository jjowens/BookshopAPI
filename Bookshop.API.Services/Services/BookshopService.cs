using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.API.Presentation.ServiceModels;
using Bookshop.API.Services.Interfaces;

namespace Bookshop.API.Services.Services
{
    public class BookshopService : IBookshopService
    {
        public BookshopService(IDatabaseService databaseService, IMapperService mapperService)
        {
            _databaseService = databaseService;
            _mapperService = mapperService;
        }

        private readonly IDatabaseService _databaseService;
        private readonly IMapperService _mapperService;

        public BookDetailsDTO GetBookDetails(int bookID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDetailsDTO> GetBooksByAuthor(int authorID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDetailsDTO> GetBooksByGenre(int genreID)
        {
            throw new NotImplementedException();
        }

        public AuthorDTO GetAuthor(int authorID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GenreDTO> GetGenres()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDetailsDTO> GetAllBooks(int booksLimit)
        {
            List<BookDetailsDTO> listOfBooks = new List<BookDetailsDTO>();

            var dbContext = _databaseService.dbContext;

            var genres = dbContext.BookGenres.ToList();

            var tempBooks = (from book in dbContext.Books
                             select new
                             {
                                 book = book,
                                 authors = (from author in dbContext.Authors
                                            join bookAuthor in dbContext.BookAuthors on author.AuthorID equals bookAuthor.AuthorID
                                            where bookAuthor.BookID == book.BookID
                                            select author),
                                 genres = (from genre in dbContext.Genres
                                           join bookGenre in dbContext.BookGenres on genre.GenreID equals bookGenre.GenreID
                                           where bookGenre.BookID == book.BookID
                                           select genre),
                             });

            listOfBooks = 

            return listOfBooks;
        }

        public ServiceResponse SaveBookDetails(BookDetailsDTO bookDetails)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse SaveAuthor(AuthorDTO author)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse SaveBookGenre(GenreDTO genre)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse DeleteBook(BookDetailsDTO bookDetails)
        {
            return DeleteBook(bookDetails.Book.BookID);
        }

        public ServiceResponse DeleteBook(BookDTO book)
        {
            return DeleteBook(book.BookID);
        }

        public ServiceResponse DeleteBook(int bookID)
        {
            ServiceResponse response = null;

            var dbContext = _databaseService.dbContext;

            var obj = dbContext.Books.FirstOrDefault(bk => bk.BookID == bookID);

            if (obj != null)
            {
                var bookAuthors = dbContext.BookAuthors.Where(bkAu => bkAu.BookID == bookID).ToList();

                var bookGenres = dbContext.BookGenres.Where(bkGen => bkGen.BookID == bookID).ToList();

                if (bookAuthors.Any())
                {
                    dbContext.BookAuthors.RemoveRange(bookAuthors);
                }

                if (bookGenres.Any())
                {
                    dbContext.BookGenres.RemoveRange(bookGenres);
                }

                dbContext.Books.Remove(obj);

                dbContext.SaveChanges();
            } else
            {
                response = createResponse(0, true, "Book does not exists", null);
            }

            return response;
        }

        public ServiceResponse DeleteGenre(GenreDTO genre)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse DeleteGenre(int genreID)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse DeleteAuthor(AuthorDTO author)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse DeleteAuthor(int authorID)
        {
            throw new NotImplementedException();
        }

        private ServiceResponse createResponse(int ID, bool isError, string logMessage, Exception ex = null)
        {
            ServiceResponse response = new ServiceResponse();

            response.ID = ID;
            response.IsError = isError;
            response.LogMessage = logMessage;
            response.exception = ex;

            return response;
        }

        private ServiceResponse createSuccessResponse(int ID, string logMessage)
        {
            ServiceResponse response = new ServiceResponse();

            response.ID = ID;
            response.IsError = false;
            response.LogMessage = logMessage;
            response.exception = null;

            return response;
        }

    }
}
