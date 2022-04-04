using Library.FilipVujeva.Contracts.Dtos;

namespace Library.FilipVujeva.Contracts.Services
{
    public interface ILibraryService
    {
        public Task<IEnumerable<BookCatalogDTO>> GetAllBooks();
        public Task ReturnBook(int personId, int bookId);
        public Task RentBook(int personId, int bookId);
        public Task<IEnumerable<BookCatalogDTO>> GetMyBooks(int personId);
    }
}
