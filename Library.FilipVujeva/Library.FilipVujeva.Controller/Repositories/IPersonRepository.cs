using Library.FilipVujeva.Contracts.Entities;

namespace Library.FilipVujeva.Contracts.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> GetWithRentedBooksById(int id); 
    }
}
