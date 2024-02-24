using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternExample.Models;
using System;

namespace RepositoryPatternExample.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<EmployeeDataModel>> GetEmployees()
        {
            return await _appDbContext.Employees
                .AsNoTracking()
                .OrderByDescending(x => x.EmployeeId)
                .ToListAsync();
        }

        public async Task<EmployeeDataModel> GetEmployee(int employeeId)
        {
            return await _appDbContext.Employees
                .AsNoTracking()
                .OrderByDescending(x => x.EmployeeId)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<EmployeeDataModel> AddEmployee(EmployeeDataModel EmployeeDataModel)
        {
            var result = await _appDbContext.Employees.AddAsync(EmployeeDataModel);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<EmployeeDataModel> UpdateEmployee(UpdateEmployeeRequestModel EmployeeDataModel)
        {
            var result = await _appDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == EmployeeDataModel.EmployeeId);

            if (result != null)
            {
                result.EmployeeName = EmployeeDataModel.EmployeeName;
                result.Age = EmployeeDataModel.Age;

                await _appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<int> DeleteEmployee(int employeeId)
        {
            EmployeeDataModel? item = await _appDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (item != null)
            {
                item.IsActive = false;
                int rowsEffected = await _appDbContext.SaveChangesAsync();
                return rowsEffected;
            }
            return 0;
        }
    }
}
