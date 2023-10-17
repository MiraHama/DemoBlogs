using Blogging.DTOs;
using Blogging.Models;

namespace Blogging.Services
{
    public interface ITagsService
    {
        Task<ServiceResponse<List<TagDto>>> GetTags();
        Task<ServiceResponse<TagDto>> GetTag(int Id);
        Task<ServiceResponse<TagDto>> CreateTag(TagDto tag);

    }
}
