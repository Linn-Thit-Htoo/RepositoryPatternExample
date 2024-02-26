using Microsoft.AspNetCore.Mvc;
using RepositoryPatternExample.Wrappers.Interfaces;

namespace RepositoryPatternExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public CustomerController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _repository.Customers.GetCustomers());
        }
    }
}
