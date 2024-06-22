using System.ComponentModel.DataAnnotations;

namespace AutoGlass.Domain.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
