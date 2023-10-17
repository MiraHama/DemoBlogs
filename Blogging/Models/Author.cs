using Blogging.DTOs;
using FluentValidation;
using System.Text.Json.Serialization;

namespace Blogging.Models
{
    public class Author
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public List<BlogPost> Posts { get; set; } = new List<BlogPost>();
    }

    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("Author name can't be empty")
                .MaximumLength(50).WithMessage("Author name max 50 characters");
        }
    }
}
