using Ecommerce_CodeFirst_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_CodeFirst_Demo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
