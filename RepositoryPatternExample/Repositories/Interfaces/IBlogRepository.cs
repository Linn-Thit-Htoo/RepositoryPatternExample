using RepositoryPatternExample.Models.Entities;

namespace RepositoryPatternExample.Repositories.Interfaces
{
    public interface IBlogRepository
    {
        Task<List<BlogDataModel>> GetBlogs();
    }
}
