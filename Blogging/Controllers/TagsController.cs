using Blogging.Data;
using Blogging.DTOs;
using Blogging.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        public readonly DataContext _context;
        public readonly ITagsService _tagsService;

        public TagsController(DataContext context, ITagsService tagsService)
        {
            _context = context;
            _tagsService = tagsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            return Ok(await _tagsService.GetTags());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTag(int Id)
        {
            ServiceResponse<TagDto> response = await _tagsService.GetTag(Id);
            return response.Success ? Ok(response) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(TagDto request)
        {
            ServiceResponse<TagDto> response = await _tagsService.CreateTag(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

    }
}
