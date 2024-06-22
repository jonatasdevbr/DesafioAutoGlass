using AutoGlass.Domain.Interfaces.Repositories;
using AutoGlass.Domain.Models;
using AutoGlass.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AutoGlass.Infra.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AutoGlassContext _context;

        public Repository(AutoGlassContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> GetById(long id)
        {
            return _context.Set<TEntity>().Where(x => x.Id == id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            var query = _context.Set<TEntity>();

            return query.AsQueryable();
        }

        public virtual void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var dbEntity = _context.Set<TEntity>().Single(x => x.Id == entity.Id);

            if (dbEntity == null)
            {
                return;
            }

            _context.Entry(dbEntity).CurrentValues.SetValues(entity);
        }

        public virtual void Delete(long id)
        {
            var dbEntity = _context.Set<TEntity>().Single(x => x.Id == id);

            if (dbEntity == null)
            {
                return;
            }

            _context.Entry(dbEntity).State = EntityState.Deleted;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
