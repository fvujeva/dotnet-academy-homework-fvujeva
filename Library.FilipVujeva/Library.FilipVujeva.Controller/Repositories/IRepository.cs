using Library.FilipVujeva.Contracts.Entities;

namespace Library.FilipVujeva.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<IList<TEntity>> GetAllAsync();

        public Task<TEntity?> GetAsync(int id);

        public void Add(TEntity entity);

        public void Delete(TEntity entity);
    }
}
