using AutoGlass.Domain.Models;
using AutoGlass.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AutoGlass.Infra.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(AutoGlassContext context) : base(context)
        {
        }

        public override IQueryable<Product> GetById(long id)
        {
            return _context.Set<Product>().Where(x => x.Id == id).Include(x => x.Supplier);
        }

        public override IQueryable<Product> GetAll()
        {
            var query = _context.Set<Product>().Include(x => x.Supplier);

            return query.AsQueryable();
        }

        public override void Delete(long id)
        {
            var dbEntity = _context.Set<Product>().Single(x => x.Id == id);

            if (dbEntity == null)
            {
                return;
            }

            dbEntity.Active = false;
        }

    }
}
