using System.ComponentModel.DataAnnotations;

namespace MVC_Assignment.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;
    }
}
