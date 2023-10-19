using Products.Api.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Products.Api.Entities
{
    public class ProductEntity : EntityBase
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }
    }
}
