using Microsoft.EntityFrameworkCore;
using RepositoryPatternExample.Data;
using RepositoryPatternExample.Models.Entities;
using RepositoryPatternExample.Repositories.Interfaces;

namespace RepositoryPatternExample.Repositories.Implementations
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _appDbContext;

        public BlogRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<List<BlogDataModel>> GetBlogs()
        {
            return await _appDbContext.Blogs
                .AsNoTracking()
                .OrderByDescending(x => x.BlogId)
                .ToListAsync();
        }
    }
}
