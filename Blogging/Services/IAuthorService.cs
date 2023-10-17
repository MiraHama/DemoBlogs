using Blogging.DTOs;
using Blogging.Models;

namespace Blogging.Services
{
    public interface IAuthorService
    {
        Task<ServiceResponse<List<GetAuthorDto>>> GetAuthors();
        Task<ServiceResponse<GetAuthorDto>> CreateAuthor(AuthorDto author);
        Task<ServiceResponse<GetAuthorDto>> DeleteAuthor(int Id);
        Task<ServiceResponse<GetAuthorDto>> GetAuthor(int Id);
    }
}
