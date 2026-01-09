using System.ComponentModel.DataAnnotations;

namespace MVC_Assignment.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, 100000)]
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
