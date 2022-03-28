using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Repositories;
using Library.FilipVujeva.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Library.FilipVujeva.Data.Db.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository<Person> _people;
        private readonly DbContext _dbContext;

        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IRepository<Person> People
            => _people ?? new Repository<Person>(_dbContext);

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
