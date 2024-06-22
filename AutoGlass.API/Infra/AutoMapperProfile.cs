using AutoGlass.API.DTOs.Product;
using AutoGlass.API.DTOs.Supplier;
using AutoGlass.Domain.Models;
using AutoMapper;

namespace AutoGlass.API.Infra
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductCreateDTO, Product>();
            CreateMap<ProductFilterDTO, Product>();

            CreateMap<Supplier, SupplierDTO>();

        }
    }
}
