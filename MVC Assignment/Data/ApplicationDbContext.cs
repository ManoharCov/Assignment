using Microsoft.EntityFrameworkCore;
using MVC_Assignment.Models;

namespace MVC_Assignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}

