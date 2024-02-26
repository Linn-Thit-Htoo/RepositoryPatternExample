using Microsoft.EntityFrameworkCore;
using RepositoryPatternExample.Models.Entities;

namespace RepositoryPatternExample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CustomerDataModel> Customers { get; set; }
        public DbSet<BlogDataModel> Blogs { get; set; }
    }
}
