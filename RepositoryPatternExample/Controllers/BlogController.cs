using Microsoft.AspNetCore.Mvc;
using RepositoryPatternExample.Wrappers.Interfaces;

namespace RepositoryPatternExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public BlogController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            try
            {
                return Ok(await _repository.Blogs.GetBlogs());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
