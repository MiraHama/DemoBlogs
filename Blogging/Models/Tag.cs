using FluentValidation;
using System.Text.Json.Serialization;

namespace Blogging.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BlogPost> Posts { get; set; } = new List<BlogPost>();
    }
    public class TagValidator : AbstractValidator<Tag>
    {
        public TagValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("Tag name can't be empty")
                .MaximumLength(20).WithMessage("Tag name max 20 characters");
        }
    }
}
