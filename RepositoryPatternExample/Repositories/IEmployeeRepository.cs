using RepositoryPatternExample.Models;

namespace RepositoryPatternExample.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDataModel>> GetEmployees();
        Task<EmployeeDataModel> GetEmployee(int employeeId);
        Task<EmployeeDataModel> AddEmployee(EmployeeDataModel employee);
        Task<EmployeeDataModel> UpdateEmployee(UpdateEmployeeRequestModel employee);
        Task<int> DeleteEmployee(int employeeId);
    }
}
