using Microsoft.AspNetCore.Mvc;
using RepositoryPatternExample.Models;
using RepositoryPatternExample.Repositories;

namespace RepositoryPatternExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #region Get employees
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            IEnumerable<EmployeeDataModel> lst = await _employeeRepository.GetEmployees();
            return Ok(lst);
        }
        #endregion

        #region Get employee
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                EmployeeDataModel? item = await _employeeRepository.GetEmployee(id);
                if (item is null)
                    return NotFound("No data found.");

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Create employee
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDataModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.EmployeeName) || model.Age == 0)
                {
                    goto Fail;
                }

                model.IsActive = true;

                EmployeeDataModel? item = await _employeeRepository.AddEmployee(model);
                if (item is null)
                {
                    goto Fail;
                }
                return StatusCode(StatusCodes.Status201Created, item);

            Fail:
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Update employee
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeRequestModel requestModel)
        {
            try
            {
                EmployeeDataModel? item = await _employeeRepository.UpdateEmployee(requestModel);
                if (item is null)
                {
                    return NotFound("No data found.");
                }
                return StatusCode(StatusCodes.Status202Accepted, item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Delete employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                int result = await _employeeRepository.DeleteEmployee(id);
                return result > 0 ? StatusCode(StatusCodes.Status202Accepted, "Employee deleted.") : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
