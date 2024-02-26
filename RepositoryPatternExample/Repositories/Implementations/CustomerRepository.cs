using Microsoft.EntityFrameworkCore;
using RepositoryPatternExample.Data;
using RepositoryPatternExample.Models.Entities;
using RepositoryPatternExample.Repositories.Interfaces;

namespace RepositoryPatternExample.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<CustomerDataModel>> GetCustomers()
        {
            return await _appDbContext.Customers
                 .AsNoTracking()
                 .ToListAsync();
        }
    }
}
