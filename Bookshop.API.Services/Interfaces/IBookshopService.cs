using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshop.API.Presentation.ServiceModels;

namespace Bookshop.API.Services.Interfaces
{
    public interface IBookshopService
    {
        BookDetails GetBookDetails(int bookID);
        IEnumerable<BookDetails> GetBooksByAuthorID(int authorID);

        IEnumerable<BookDetails> GetBooksByAuthor(string firstName, string lastName);

        IEnumerable<BookDetails> GetBooksByGenre(int genreID);

        Author GetAuthor(int authorID);

        IEnumerable<Genre> GetGenres();

        IEnumerable<BookDetails> GetAllBooks(int booksLimit);

        ServiceResponse SaveBookDetails(BookDetails bookDetails);
        ServiceResponse SaveAuthor(Author author);
        ServiceResponse SaveBookAuthor(BookAuthor bookAuthor);
        ServiceResponse SaveBookAuthor(int bookID, int authorID);
        ServiceResponse SaveGenre(Genre genre);
        ServiceResponse SaveBookGenre(BookGenre genre);

        ServiceResponse DeleteBook(BookDetails bookDetails);
        ServiceResponse DeleteBook(Book book);
        ServiceResponse DeleteBook(int bookID);

        ServiceResponse DeleteGenre(Genre genre);
        ServiceResponse DeleteGenre(int genreID);

        ServiceResponse DeleteAuthor(Author author);
        ServiceResponse DeleteAuthor(int authorID);

         IEnumerable<BookDetails> SearchBooks(Search search);
         IEnumerable<Author> GetAllAuthors();


    }
}
