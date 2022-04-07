using Library.FilipVujeva.API.Exceptions;
using Library.FilipVujeva.Contracts.Dtos;
using Library.FilipVujeva.Contracts.Repositories;
using Library.FilipVujeva.Contracts.Services;

namespace Library.FilipVujeva.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IUnitOfWork _context;

        public LibraryService(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookCatalogDTO>> GetAllBooks()
        {
            var books = await _context.Books.GetAllAsync();
            return books.Select(book => book.ToCatalogDto());
        }

        public async Task<IEnumerable<BookCatalogDTO>> GetMyBooks(int personId)
        {
            var person = await _context.People.GetWithRentedBooksById(personId);

            return person.RentedBooks.ConvertAll<BookCatalogDTO>(book => book.ToCatalogDto());
        }

        public async Task RentBook(int personId, int bookId)
        {
            var book = await _context.Books.GetAsync(bookId);

            var person = await _context.People.GetWithRentedBooksById(personId);

            if (book == null)
            {
                throw new EntityNotFoundException("That books does not exist in our library!");
            }

            if (person == null)
            {
                throw new EntityNotFoundException("That person does not exist in our library!");
            }

            person.RentBook(book);
            await _context.SaveChangesAsync();
        }

        public async Task ReturnBook(int personId, int bookId)
        {
            var book = await _context.Books.GetAsync(bookId);

            var person = await _context.People.GetWithRentedBooksById(personId);

            if (book == null)
            {
                throw new EntityNotFoundException("That book does not exist in our library!");
            }

            if (person == null)
            {
                throw new EntityNotFoundException("That person does not exist in our library!");
            }

            person.ReturnBook(bookId);
            await _context.SaveChangesAsync();
        }
    }
}
