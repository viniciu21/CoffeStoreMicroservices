using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Core.Models
{
    public class ProductModel
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }
    }
}
