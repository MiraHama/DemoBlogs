using Blogging.DTOs;
using Blogging.Models;

namespace Blogging.Services
{
    public interface IBlogPostService
    {
        Task<ServiceResponse<GetBlogDto>> AddBlogPost(CreateBlogDto blogpost);
        Task<ServiceResponse<List<GetBlogDto>>> GetBlogPosts();
        Task<ServiceResponse<GetBlogDto>> DeleteBlog(int Id);
        Task<ServiceResponse<GetBlogDto>> GetBlogPost(int Id);

    }
}
