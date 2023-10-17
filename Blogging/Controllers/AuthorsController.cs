
using Blogging.Data;
using Blogging.DTOs;

using Blogging.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public readonly DataContext _context;
        public readonly IAuthorService _authorService;
        public AuthorsController(DataContext context, IAuthorService authorService)
        {
            _context = context;
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AuthorDto request)
        {
            ServiceResponse<GetAuthorDto> response = await _authorService.CreateAuthor(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            return Ok(await _authorService.GetAuthors());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAuthor(int Id)
        {
            ServiceResponse<GetAuthorDto> response = await _authorService.GetAuthor(Id);
            return response.Success ? Ok(response) : NotFound();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAuthor(int Id)
        {
            ServiceResponse<GetAuthorDto> response = await _authorService.DeleteAuthor(Id);
            return response.Success ? NoContent() : NotFound();
        }
    }
}
