using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoGlass.Domain.Models
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        [Required, MinLength(1), MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public bool? Active { get; set; }

        public DateTime? Manufacture { get; set; }

        public DateTime? Expiration { get; set; }

        [Required]
        public long? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

    }
}
