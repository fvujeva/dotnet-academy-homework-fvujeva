using Library.FilipVujeva.Contracts.Entities;

namespace Library.FilipVujeva.API.Exceptions
{

    public class BookNotAvailableException : Exception
    {
        public Book Book { get; }

        public BookNotAvailableException(Book book) : base($"Book {book.Title} is not available")
        {
            Book = book;
        }
    }
}
