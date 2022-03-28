using Library.FilipVujeva.Contracts.Entities;

namespace Library.FilipVujeva.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Person> People { get; }

        Task SaveChangesAsync();
    }
}
