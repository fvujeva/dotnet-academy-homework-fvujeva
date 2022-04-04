using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Repositories;
using Library.FilipVujeva.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Library.FilipVujeva.Data.Db.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPersonRepository _people;
        private readonly IRepository<Book> _books;
        private readonly DbContext _dbContext;

        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IPersonRepository People
            => _people ?? new PersonRepository(_dbContext);

        public IRepository<Book> Books
            => _books ?? new Repository<Book>(_dbContext);

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
