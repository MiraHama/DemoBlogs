using Azure;
using Blogging.Controllers;
using Blogging.Data;
using Blogging.DTOs;
using Blogging.Models;
using Blogging.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        public readonly DataContext _context;
        public readonly IBlogPostService _blogPostService;

        public BlogPostsController(DataContext context, IBlogPostService blogPostService) 
        {
            _context = context;
            _blogPostService = blogPostService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost(CreateBlogDto request)
        {
            ServiceResponse<GetBlogDto> response = await _blogPostService.AddBlogPost(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetBlogPosts()
        {
            return Ok(await _blogPostService.GetBlogPosts());
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBlog(int Id)
        {
            ServiceResponse<GetBlogDto> response = await _blogPostService.DeleteBlog(Id);
            return response.Success ? NoContent() : NotFound();
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBlogPost(int Id)
        {
            ServiceResponse<GetBlogDto> response = await _blogPostService.GetBlogPost(Id);
            return response.Success ? Ok(response) : NotFound();
        }
    }
}
 