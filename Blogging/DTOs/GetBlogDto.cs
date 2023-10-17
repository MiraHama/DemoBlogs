using Blogging.Models;

namespace Blogging.DTOs
{
    public class GetBlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string TextBody { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public AuthorDto? Author { get; set; }
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
    }
}
