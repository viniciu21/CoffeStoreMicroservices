using Microsoft.EntityFrameworkCore;
using ProductsApi.Core.Models;

namespace ProductsApi.Core.Common.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<ProductModel> Products { get; set; }

    }
}
