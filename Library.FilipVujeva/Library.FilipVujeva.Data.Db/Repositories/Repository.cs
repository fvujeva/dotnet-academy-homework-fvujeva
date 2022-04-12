using System.Linq;
using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.FilipVujeva.Data.Db.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> _context;

        public Repository(DbContext dbContext)
        {
            _context = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (_context.Contains(entity))
            {
                _context.Remove(entity);
            }
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _context.ToListAsync();
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            return await _context.FindAsync(id);
        }
    }
}
