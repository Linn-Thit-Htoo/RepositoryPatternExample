using RepositoryPatternExample.Models.Entities;

namespace RepositoryPatternExample.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDataModel>> GetCustomers();
    }
}
