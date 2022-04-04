using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.FilipVujeva.Data.Db.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Person> GetWithRentedBooksById(int id)
        {
            var person = await _context.Where(person => person.Id == id)
                .Include(person => person.RentedBooks)
                .ThenInclude(person => person.People)
                .SingleOrDefaultAsync();

            if (person == null)
            {
                throw new Exception("Not Found!");
            }

            return person;
        }
    }
}
