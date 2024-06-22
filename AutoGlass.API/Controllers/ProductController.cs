using AutoGlass.API.DTOs.Product;
using AutoGlass.Domain.Models;
using AutoGlass.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AutoGlass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProductService _productService;

        public ProductController(IMapper mapper, ProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductDTO> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromBody] ProductFilterDTO filter = null)
        {
            var products = _productService.GetAll(page: page, pageSize: pageSize, filter: _mapper.Map<Product>(filter));

            var rtn = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return rtn;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> Get(long id)
        {
            var rtn = _productService.GetById(id);

            if (rtn == null)
            {
                return NotFound(new { message = $"Produto com Id={id} não encontrado." });
            }

            return _mapper.Map<ProductDTO>(rtn);
        }


        [HttpPost]
        public ActionResult<ProductDTO> Create(ProductCreateDTO product)
        {
            var rtn = _productService.Create(_mapper.Map<Product>(product));

            return Ok(rtn);
        }

        [HttpPut]
        public ActionResult<ProductDTO> Update(ProductUpdateDTO product)
        {
            var rtn = _productService.Update(_mapper.Map<Product>(product));

            return Ok(rtn);
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductDTO> Delete(long id)
        {
            _productService.Delete(id);

            return Ok();
        }
    }
}
