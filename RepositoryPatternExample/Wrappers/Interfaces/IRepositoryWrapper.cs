using RepositoryPatternExample.Repositories.Interfaces;

namespace RepositoryPatternExample.Wrappers.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customers { get; }
        IBlogRepository Blogs { get; }
        void Save();
    }
}
