using AutoGlass.Domain.Interfaces.Repositories;
using AutoGlass.Domain.Models;
using AutoGlass.Domain.Services;
using AutoGlass.Infra.Context;
using AutoGlass.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AutoGlass.Application.DataInjection
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<AutoGlassContext>(options => options.UseSqlServer(conection));

            services.AddScoped(typeof(IRepository<Product>), typeof(ProductRepository));
            services.AddScoped(typeof(ProductService));
        }
    }
}
