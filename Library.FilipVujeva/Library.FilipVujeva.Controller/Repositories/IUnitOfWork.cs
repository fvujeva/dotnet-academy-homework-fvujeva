using Library.FilipVujeva.Contracts.Entities;

namespace Library.FilipVujeva.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        IPersonRepository People { get; }
        IRepository<Book> Books { get; }

        Task SaveChangesAsync();
    }
}
