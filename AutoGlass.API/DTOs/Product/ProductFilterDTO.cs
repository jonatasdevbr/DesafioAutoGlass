using System;

namespace AutoGlass.API.DTOs.Product
{
    public class ProductFilterDTO
    {
        public string Description { get; set; }

        public bool? Active { get; set; }

        public DateTime? Manufacture { get; set; }

        public DateTime? Expiration { get; set; }

        public long? SupplierId { get; set; }
    }
}
