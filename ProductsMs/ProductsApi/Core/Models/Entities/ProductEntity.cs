using ProductsApi.Core.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Core.Models.Entities
{
    public class ProductEntity : EntityBase
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }
    }
}
