using Blogging.Models;

namespace Blogging.DTOs
{
    public class GetAuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BlogDto> Posts { get; set; } = new List<BlogDto>();
    }
}
