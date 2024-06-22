using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoGlass.Domain.Models
{
    [Table("Supplier")]
    public class Supplier : BaseEntity
    {
        public string Description { get; set; }

        public string CNPJ { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
