using Microsoft.EntityFrameworkCore;
using RepositoryPatternExample.Models;

namespace RepositoryPatternExample
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EmployeeDataModel> Employees { get; set; }
    }
}
