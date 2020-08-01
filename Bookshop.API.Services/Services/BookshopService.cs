using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.API.Core.DB;
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

        public IEnumerable<Presentation.ServiceModels.BookDetails> SearchBooks(Presentation.ServiceModels.Search search)
        {
            var dbContext = _databaseService.dbContext;
            var mapperService = _mapperService.mapper;

            var searchQuery = (from book in dbContext.Books
                             select new
                             {
                                 book,
                                 authors = (from author in dbContext.Authors
                                            join bookAuthor in dbContext.BookAuthors on author.AuthorID equals bookAuthor.AuthorID
                                            where bookAuthor.BookID == book.BookID
                                            select author),
                                 genres = (from genre in dbContext.Genres
                                           join bookGenre in dbContext.BookGenres on genre.GenreID equals bookGenre.GenreID
                                           where bookGenre.BookID == book.BookID
                                           select genre),
                             });

            if (search.BookID > 0)
            {
                searchQuery = searchQuery.Where(sq => sq.book.BookID == search.BookID);
            }

            if (!string.IsNullOrEmpty(search.BookTitle))
            {
                searchQuery = searchQuery.Where(sq => sq.book.Title == search.BookTitle);
            }

            if (!string.IsNullOrEmpty(search.FirstName))
            {
                //searchQuery = searchQuery.Where(sq => sq.authors.Where(au => au.Firstname == search.FirstName));
            }

            if (!string.IsNullOrEmpty(search.LastName))
            {
                //searchQuery = searchQuery.Where(sq => sq.authors.Where(au => au.Firstname == search.FirstName));
            }

            if (search.AuthorID > 0)
            {
                //searchQuery = searchQuery.Where(sq => sq.authors.FirstOrDefault(au => au.AuthorID == search.AuthorID));
            }

            var tempResults = searchQuery.ToList();

            var searchResults = (from bookObj in tempResults
                                 select new Presentation.ServiceModels.BookDetails()
                                   {
                                       Book = mapperService.Map<Book, Presentation.ServiceModels.Book>(bookObj.book),
                                       Authors = mapperService.Map<IList<Author>, IList<Presentation.ServiceModels.Author>>(bookObj.authors.ToList()),
                                       Genres = mapperService.Map<IList<Genre>, IList<Presentation.ServiceModels.Genre>>(bookObj.genres.ToList())
                                   }).ToList();

            return searchResults;
        }

        public Presentation.ServiceModels.BookDetails GetBookDetails(int bookID)
        {
            Presentation.ServiceModels.Search searchParameters = new Presentation.ServiceModels.Search();

            searchParameters.BookID = bookID;

            var bookDetails = SearchBooks(searchParameters);

            return bookDetails.ToList()[0];
        }

        public IEnumerable<Presentation.ServiceModels.BookDetails> GetBooksByAuthorID(int authorID)
        {
            Presentation.ServiceModels.Search searchParameters = new Presentation.ServiceModels.Search();

            searchParameters.AuthorID = authorID;

            var bookDetails = SearchBooks(searchParameters);

            return bookDetails;
        }

        public IEnumerable<Presentation.ServiceModels.BookDetails> GetBooksByAuthor(string firstName, string lastName)
        {
            Presentation.ServiceModels.Search searchParameters = new Presentation.ServiceModels.Search();

            searchParameters.FirstName = firstName;
            searchParameters.LastName = lastName;

            var bookDetails = SearchBooks(searchParameters);

            return bookDetails;
        }

        public IEnumerable<Presentation.ServiceModels.BookDetails> GetBooksByGenre(int genreID)
        {
            Presentation.ServiceModels.Search searchParameters = new Presentation.ServiceModels.Search();

            var bookDetails = SearchBooks(searchParameters);

            return bookDetails;
        }

        public Presentation.ServiceModels.Author GetAuthor(int authorID)
        {
            var author = _databaseService.dbContext.Authors.FirstOrDefault(x => x.AuthorID == authorID);

            var newAuthor = _mapperService.mapper.Map<Author, Presentation.ServiceModels.Author>(author);

            return newAuthor;
        }

        public IEnumerable<Presentation.ServiceModels.Genre> GetGenres()
        {
            var genres = _databaseService.dbContext.Genres;
            var mapperService = _mapperService.mapper;

            var listOfGenres = mapperService.Map<IEnumerable<Genre>, IEnumerable<Presentation.ServiceModels.Genre>>(genres);

            return listOfGenres;
        }

        public IEnumerable<Presentation.ServiceModels.BookDetails> GetAllBooks(int booksLimit)
        {
            var dbContext = _databaseService.dbContext;
            var mapperService = _mapperService.mapper;

            var genres = dbContext.BookGenres.ToList();

            var tempBooks = (from book in dbContext.Books
                             select new
                             {
                                 book,
                                 authors = (from author in dbContext.Authors
                                            join bookAuthor in dbContext.BookAuthors on author.AuthorID equals bookAuthor.AuthorID
                                            where bookAuthor.BookID == book.BookID
                                            select author).ToList(),
                                 genres = (from genre in dbContext.Genres
                                           join bookGenre in dbContext.BookGenres on genre.GenreID equals bookGenre.GenreID
                                           where bookGenre.BookID == book.BookID
                                           select genre).ToList(),
                             }).ToList();

            var listOfBooks = (from bookObj in tempBooks
                           select new Presentation.ServiceModels.BookDetails()
                            {
                                Book = mapperService.Map<Book, Presentation.ServiceModels.Book>(bookObj.book),
                                Authors = mapperService.Map<IList<Author>, IList<Presentation.ServiceModels.Author>>(bookObj.authors),
                                Genres = mapperService.Map<IList<Genre>, IList<Presentation.ServiceModels.Genre>>(bookObj.genres)
                            });

            return listOfBooks;
        }

        public Presentation.ServiceModels.ServiceResponse SaveBookDetails(Presentation.ServiceModels.BookDetails bookDetails)
        {
            var response = new Presentation.ServiceModels.ServiceResponse();
            var dbContext = _databaseService.dbContext;
            var mapperService = _mapperService.mapper;

            var genres = dbContext.BookGenres.ToList();

            // CHECK IF BOOK ALREADY EXISTS
            var bookQuery = (from book in dbContext.Books
                             select book);

            // FIND BOOK BY ID OR TITLE
            if (bookDetails.Book.BookID > 0)
            {
                bookQuery = (from book in bookQuery
                             where book.BookID == bookDetails.Book.BookID
                             select book);
            } else
            {
                bookQuery = (from book in bookQuery
                             where book.Title == bookDetails.Book.Title
                             select book);
            }

            var currentBook = bookQuery.FirstOrDefault();

            Book newBook = new Book();

            // CREATE NEW BOOK
            if (currentBook == null)
            {
                newBook = mapperService.Map<Presentation.ServiceModels.Book, Book>(bookDetails.Book);

                dbContext.Books.Add(newBook);
            } else
            {
                // UPDATE BOOK
                var currentBookID = currentBook.BookID;

                currentBook = mapperService.Map<Presentation.ServiceModels.Book, Book>(bookDetails.Book, currentBook);
                currentBook.BookID = currentBookID;

                newBook = currentBook;
            }

            dbContext.SaveChanges();

            // SAVE AUTHORS AND CREATE LINKED RECORDS
            foreach(var bookAuthor in bookDetails.Authors)
            {
                var authorResponse = SaveAuthor(bookAuthor);

                var bookAuthorResponse = SaveBookAuthor(newBook.BookID, authorResponse.ID);
            }

            // SAVE GENRES AND CREATE LINKED RECORDS
            foreach (var bookGenre in bookDetails.Genres)
            {
                var genreResponse = SaveGenre(bookGenre);

                var bookGenreResponse = SaveBookGenre(newBook.BookID, genreResponse.ID);
            }

            response.ID = newBook.BookID;

            return response;
        }

        public Presentation.ServiceModels.ServiceResponse SaveAuthor(Presentation.ServiceModels.Author author)
        {
            var response = new Presentation.ServiceModels.ServiceResponse();
            var dbContext = _databaseService.dbContext;
            var mapperService = _mapperService.mapper;

            // SEARCH FOR AUTHOR
            var authorQuery = dbContext.Authors.AsQueryable();

            if (author.AuthorID > 0)
            {
                authorQuery = (from au in authorQuery where au.AuthorID == author.AuthorID select au);
            }
            else
            {
                authorQuery = (from au in authorQuery where au.Firstname == author.FirstName && au.LastName == author.LastName select au);
            }

            // GET AUTHOR RECORD
            var authorObj = authorQuery.FirstOrDefault();

            // UPDATE AUTHOR
            if (authorObj != null)
            {
                authorObj.Firstname = author.FirstName;
                authorObj.LastName = author.LastName;
            } else
            {
                // CREATE NEW AUTHOR
                authorObj = new Author();

                authorObj.Firstname = author.FirstName;
                authorObj.LastName = author.LastName;

                dbContext.Authors.Add(authorObj);
            }

            dbContext.SaveChanges();

            response = createSuccessResponse(authorObj.AuthorID, "Saved Author");

            return response;
        }

        public Presentation.ServiceModels.ServiceResponse SaveBookGenre(Presentation.ServiceModels.BookGenre bookGenre)
        {
            return SaveBookGenre(bookGenre.BookID, bookGenre.GenreID);
        }

        public Presentation.ServiceModels.ServiceResponse SaveBookGenre(int bookID, int genreID)
        {
            Presentation.ServiceModels.ServiceResponse response = new Presentation.ServiceModels.ServiceResponse();

            var dbContext = _databaseService.dbContext;

            var bookGenreObj = dbContext.BookGenres.FirstOrDefault(bk => bk.BookID == bookID && bk.GenreID == genreID);

            if (bookGenreObj == null)
            {
                bookGenreObj = new BookGenre();
                bookGenreObj.GenreID = genreID;
                bookGenreObj.BookID = bookID;

                dbContext.BookGenres.Add(bookGenreObj);

                dbContext.SaveChanges();

                response = createSuccessResponse(bookGenreObj.BookGenreID, "Saved BookGenre");
            }
            else
            {
                response = createSuccessResponse(bookGenreObj.BookGenreID, "BookAuthor already exists");
            }

            return response;
        }

        public Presentation.ServiceModels.ServiceResponse SaveGenre(Presentation.ServiceModels.Genre genre)
        {
            var response = new Presentation.ServiceModels.ServiceResponse();
            var dbContext = _databaseService.dbContext;
            var mapperService = _mapperService.mapper;

            var genreQuery = dbContext.Genres.AsQueryable();

            if (genre.GenreID > 0)
            {
                genreQuery = genreQuery.Where(ge => ge.GenreID == genre.GenreID);
            }
            else
            {
                genreQuery = genreQuery.Where(ge => ge.GenreName == genre.GenreName);
            }

            var genreObj = genreQuery.FirstOrDefault();

            if (genreObj != null)
            {
                var currentID = genreObj.GenreID;
                genreObj.GenreName = genre.GenreName;
                genreObj.GenreID = currentID;
            }
            else
            {
                genreObj = new Genre();

                genreObj.GenreName = genre.GenreName;

                dbContext.Genres.Add(genreObj);
            }

            dbContext.SaveChanges();

            response = createSuccessResponse(genreObj.GenreID, "Saved Genre");

            return response;
        }

        public Presentation.ServiceModels.ServiceResponse DeleteBook(Presentation.ServiceModels.BookDetails bookDetails)
        {
            return DeleteBook(bookDetails.Book.BookID);
        }

        public Presentation.ServiceModels.ServiceResponse DeleteBook(Presentation.ServiceModels.Book book)
        {
            return DeleteBook(book.BookID);
        }

        public Presentation.ServiceModels.ServiceResponse DeleteBook(int bookID)
        {
            Presentation.ServiceModels.ServiceResponse response = createResponse(0, false, string.Empty);

            var dbContext = _databaseService.dbContext;

            var obj = dbContext.Books.FirstOrDefault(bk => bk.BookID == bookID);

            // REMOVE ALL LINKED RECORDS TO BOOK DUE TO BE DELETED
            if (obj != null)
            {
                var bookAuthors = dbContext.BookAuthors.Where(bkAu => bkAu.BookID == bookID).ToList();

                var bookGenres = dbContext.BookGenres.Where(bkGen => bkGen.BookID == bookID).ToList();

                // DELETE LINKED AUTHOR RECORDS
                if (bookAuthors.Any())
                {
                    dbContext.BookAuthors.RemoveRange(bookAuthors);
                }

                // DELETE LINKED GENRES RECORDS
                if (bookGenres.Any())
                {
                    dbContext.BookGenres.RemoveRange(bookGenres);
                }

                dbContext.Books.Remove(obj);

                dbContext.SaveChanges();

                response = createSuccessResponse(0, "Deleted Book");
            } else
            {
                response = createResponse(0, true, "Book does not exists", null);
            }

            return response;
        }

        public Presentation.ServiceModels.ServiceResponse DeleteGenre(Presentation.ServiceModels.Genre genre)
        {
            return DeleteGenre(genre.GenreID);
        }

        public Presentation.ServiceModels.ServiceResponse DeleteGenre(int genreID)
        {
            Presentation.ServiceModels.ServiceResponse response = createResponse(0, false, string.Empty);

            var dbContext = _databaseService.dbContext;

            var obj = dbContext.Genres.FirstOrDefault(ge => ge.GenreID == genreID);

            // REMOVE ALL LINKED RECORDS TO GENRES DUE TO BE DELETED
            if (obj != null)
            {
                var bookGenres = dbContext.BookGenres.Where(bkGen => bkGen.GenreID == genreID).ToList();

                // DELETE LINKED GENRES RECORDS
                if (bookGenres.Any())
                {
                    dbContext.BookGenres.RemoveRange(bookGenres);
                }

                dbContext.Genres.Remove(obj);

                dbContext.SaveChanges();

                response = createSuccessResponse(0, "Deleted Genre");
            }
            else
            {
                response = createResponse(0, true, "Genre does not exists", null);
            }

            return response;
        }

        public Presentation.ServiceModels.ServiceResponse DeleteAuthor(Presentation.ServiceModels.Author author)
        {
            return DeleteAuthor(author.AuthorID);
        }

        public Presentation.ServiceModels.ServiceResponse DeleteAuthor(int authorID)
        {
            Presentation.ServiceModels.ServiceResponse response = createResponse(0, false, string.Empty);

            var dbContext = _databaseService.dbContext;

            var obj = dbContext.Authors.FirstOrDefault(au => au.AuthorID == authorID);

            // REMOVE ALL LINKED RECORDS TO GENRES DUE TO BE DELETED
            if (obj != null)
            {
                var bookAuthors = dbContext.BookAuthors.Where(bkAu => bkAu.AuthorID == authorID).ToList();

                // DELETE LINKED GENRES RECORDS
                if (bookAuthors.Any())
                {
                    dbContext.BookAuthors.RemoveRange(bookAuthors);
                }

                dbContext.Authors.Remove(obj);

                dbContext.SaveChanges();

                response = createSuccessResponse(0, "Deleted Author");
            }
            else
            {
                response = createResponse(0, true, "Author does not exists", null);
            }

            return response;
        }

        private Presentation.ServiceModels.ServiceResponse createResponse(int ID, bool containErrors, string logMessage, Exception ex = null)
        {
            Presentation.ServiceModels.ServiceResponse response = new Presentation.ServiceModels.ServiceResponse();

            response.ID = ID;
            response.ContainErrors = containErrors;
            response.LogMessage = logMessage;
            response.exception = ex;

            return response;
        }

        private Presentation.ServiceModels.ServiceResponse createSuccessResponse(int ID, string logMessage)
        {
            Presentation.ServiceModels.ServiceResponse response = new Presentation.ServiceModels.ServiceResponse();

            response.ID = ID;
            response.ContainErrors = false;
            response.LogMessage = logMessage;
            response.exception = null;

            return response;
        }


        public IEnumerable<Presentation.ServiceModels.Author> GetAllAuthors()
        {
            var authors = _databaseService.dbContext.Authors.OrderBy(au => au.LastName);

            var listOfAuthors = _mapperService.mapper.Map<IEnumerable<Author>, IEnumerable<Presentation.ServiceModels.Author>>(authors);

            return listOfAuthors;
        }

        public Presentation.ServiceModels.ServiceResponse SaveBookAuthor(Presentation.ServiceModels.BookAuthor bookAuthor)
        {
            return SaveBookAuthor(bookAuthor.BookID, bookAuthor.AuthorID);
        }

        public Presentation.ServiceModels.ServiceResponse SaveBookAuthor(int bookID, int authorID)
        {
            Presentation.ServiceModels.ServiceResponse response = new Presentation.ServiceModels.ServiceResponse();

            var dbContext = _databaseService.dbContext;

            var bookAuthorObj = dbContext.BookAuthors.FirstOrDefault(bk => bk.BookID == bookID && bk.AuthorID == authorID);

            if (bookAuthorObj == null)
            {
                bookAuthorObj = new BookAuthor();
                bookAuthorObj.AuthorID = authorID;
                bookAuthorObj.BookID = bookID;

                dbContext.BookAuthors.Add(bookAuthorObj);

                dbContext.SaveChanges();

                response = createSuccessResponse(bookAuthorObj.BookAuthorID, "Saved BookAuthor");
            } else
            {
                response = createSuccessResponse(bookAuthorObj.BookAuthorID, "BookAuthor already exists");
            }

            return response;
        }


    }
}
