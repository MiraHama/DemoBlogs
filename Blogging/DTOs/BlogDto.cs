using Blogging.Models;

namespace Blogging.DTOs
{
    public class BlogDto
    {
        public int? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string TextBody { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
    }
}
