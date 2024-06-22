using AutoGlass.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoGlass.Infra.Context
{
    public class AutoGlassContext : DbContext
    {
        public AutoGlassContext(DbContextOptions<AutoGlassContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
