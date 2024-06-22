using AutoGlass.Domain.Exceptions;
using AutoGlass.Domain.Interfaces.Repositories;
using AutoGlass.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace AutoGlass.Domain.Services
{
    public sealed class ProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetById(long id)
        {
            return _productRepository.GetById(id).FirstOrDefault(x => x.Active == true);
        }

        public IEnumerable<Product> GetAll(int page = 1, int pageSize = 10, Product filter = null)
        {
            var query = _productRepository.GetAll();

            if (filter != null)
            {
                if (filter.Active != null)
                {
                    query = query.Where(x => x.Active == filter.Active);
                }
                else
                {
                    query = query.Where(x => x.Active == true);
                }

                if (!string.IsNullOrWhiteSpace(filter.Description))
                {
                    query = query.Where(x => x.Description == filter.Description);
                }

                if (filter.Expiration != null)
                {
                    query = query.Where(x => x.Expiration == filter.Expiration);
                }

                if (filter.Manufacture != null)
                {
                    query = query.Where(x => x.Manufacture == filter.Manufacture);
                }

                if (filter.SupplierId != null)
                {
                    query = query.Where(x => x.SupplierId == filter.SupplierId);
                }
            }

            return query.OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize).Take(pageSize)
                .ToList();
        }

        public long Create(Product product)
        {
            if (product.Expiration <= product.Manufacture)
            {
                throw new BusinessException("Data de expiração deve ser maior que a data de Fabricação.");
            }

            product.Active = true;

            _productRepository.Create(product);
            _productRepository.Save();

            return product.Id;
        }

        public long Update(Product product)
        {
            if (!_productRepository.GetById(product.Id).Any())
            {
                throw new BusinessException("Produto não encontrado.");
            }

            if (product.Expiration <= product.Manufacture)
            {
                throw new BusinessException("Data de expiração deve ser maior que a data de Fabricação.");
            }

            _productRepository.Update(product);
            _productRepository.Save();

            return product.Id;
        }

        public void Delete(long id)
        {
            if (!_productRepository.GetById(id).Any())
            {
                throw new BusinessException("Produto não encontrado.");
            }

            _productRepository.Delete(id);
            _productRepository.Save();
        }
    }
}
