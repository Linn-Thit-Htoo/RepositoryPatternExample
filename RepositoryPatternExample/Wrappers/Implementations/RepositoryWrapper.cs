using RepositoryPatternExample.Data;
using RepositoryPatternExample.Repositories.Implementations;
using RepositoryPatternExample.Repositories.Interfaces;
using RepositoryPatternExample.Wrappers.Interfaces;

namespace RepositoryPatternExample.Wrappers.Implementations
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ICustomerRepository _customerRepository;
        private IBlogRepository _blogRepository;
        private readonly AppDbContext _appDbContext;

        public RepositoryWrapper(ICustomerRepository customerRepository, IBlogRepository blogRepository, AppDbContext appDbContext)
        {
            _customerRepository = customerRepository;
            _blogRepository = blogRepository;
            _appDbContext = appDbContext;
        }

        public ICustomerRepository Customers
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_appDbContext);
                }

                return _customerRepository;
            }
        }

        public IBlogRepository Blogs
        {
            get
            {
                if (_blogRepository == null)
                {
                    _blogRepository = new BlogRepository(_appDbContext);
                }

                return _blogRepository;
            }
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
