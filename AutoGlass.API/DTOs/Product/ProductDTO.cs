using AutoGlass.API.DTOs.Supplier;
using System;

namespace AutoGlass.API.DTOs.Product
{
    public class ProductDTO
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public DateTime? Manufacture { get; set; }

        public DateTime? Expiration { get; set; }

        public SupplierDTO Supplier { get; set; }
    }
}
