using System.Linq;

namespace AutoGlass.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetById(long id);
        IQueryable<TEntity> GetAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(long id);
        void Save();
    }
}
