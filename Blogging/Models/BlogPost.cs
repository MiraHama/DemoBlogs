using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Blogging.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string TextBody { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; } = new Author();
        public List<Tag> Tags { get; set; } = new List<Tag>();  
    }

    public class BlogPostValidator : AbstractValidator<BlogPost>
    {
        public BlogPostValidator() 
        {
            RuleFor(b => b.Title).NotEmpty().WithMessage("Blog Title can't be empty")
                .MaximumLength(50).WithMessage("Blog title max 50 characters");
            RuleFor(b => b.TextBody).NotEmpty().WithMessage("Blog is missing a text body");
            RuleFor(b => b.Author).SetValidator(new AuthorValidator());
            RuleForEach(b => b.Tags).SetValidator(new TagValidator());

        }
    }
}
