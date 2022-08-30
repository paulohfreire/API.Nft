using API.Nft.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Nft.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Owner>? Owner { get; set; }

    }
}
