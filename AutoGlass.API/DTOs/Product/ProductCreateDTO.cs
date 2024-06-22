using System;
using System.ComponentModel.DataAnnotations;

namespace AutoGlass.API.DTOs.Product
{
    public class ProductCreateDTO
    {
        [Required, MinLength(1), MaxLength(255)]
        public string Description { get; set; }

        public DateTime? Manufacture { get; set; }

        public DateTime? Expiration { get; set; }

        [Required]
        public long SupplierId { get; set; }
    }
}
