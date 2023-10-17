namespace Blogging.DTOs
{
    public class CreateBlogDto
    {
        public string Title { get; set; } = string.Empty;
        public string TextBody { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new List<string>();
    }
}
