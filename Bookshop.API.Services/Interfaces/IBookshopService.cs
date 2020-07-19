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
        BookDetailsDTO GetBookDetails(int bookID);
        IEnumerable<BookDetailsDTO> GetBooksByAuthor(int authorID);

        IEnumerable<BookDetailsDTO> GetBooksByGenre(int genreID);

        AuthorDTO GetAuthor(int authorID);

        IEnumerable<GenreDTO> GetGenres();

        IEnumerable<BookDetailsDTO> GetAllBooks(int booksLimit);

        ServiceResponse SaveBookDetails(BookDetailsDTO bookDetails);
        ServiceResponse SaveAuthor(AuthorDTO author);
        ServiceResponse SaveBookGenre(GenreDTO genre);

        ServiceResponse DeleteBook(BookDetailsDTO bookDetails);
        ServiceResponse DeleteBook(BookDTO book);
        ServiceResponse DeleteBook(int bookID);

        ServiceResponse DeleteGenre(GenreDTO genre);
        ServiceResponse DeleteGenre(int genreID);

        ServiceResponse DeleteAuthor(AuthorDTO author);
        ServiceResponse DeleteAuthor(int authorID);

    }
}
