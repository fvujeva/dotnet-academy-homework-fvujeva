using Library.FilipVujeva.Contracts.Entities;

namespace Library.FilipVujeva.Contracts.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person?> GetWithRentedBooksById(int id);

        public Task<IEnumerable<Person>> GetAllWithRentedBeforeDate(DateTime date);
    }
}
