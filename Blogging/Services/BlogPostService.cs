using AutoMapper;
using Blogging.Data;
using Blogging.DTOs;
using Blogging.Models;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;

namespace Blogging.Services
{
    public class BlogPostService : IBlogPostService
    {
        public readonly DataContext _context;
        private readonly IMapper _mapper;

        public BlogPostService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetBlogDto>> AddBlogPost(CreateBlogDto blogpost)
        {
            ServiceResponse<GetBlogDto> serviceResponse = new ServiceResponse<GetBlogDto>();
            Author? blogAuthor = await _context.Authors.FirstOrDefaultAsync(a => a.Name == blogpost.AuthorName);
            List<Tag> tags = new List<Tag>();
            if (blogpost.Tags != null)
            {
                blogpost.Tags.ForEach(tag =>
                {
                    Tag? tagItem = _context.Tags.FirstOrDefault(t => t.Name == tag);
                    if (tagItem == null)
                    {
                        tagItem = new Tag() { Name = tag };
                    }
                    tags.Add(tagItem);
                });
            }
            BlogPost newBlogPost = new BlogPost()
            {
                Title = blogpost.Title,
                TextBody = blogpost.TextBody,
                Author = blogAuthor != null ? blogAuthor : new Author() { Name = blogpost.AuthorName },
                Tags = tags
            };
            BlogPostValidator validator = new BlogPostValidator();
            ValidationResult results = validator.Validate(newBlogPost);
            if (!results.IsValid)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = results.ToString(", ");
                return serviceResponse;
            }

            _context.BlogPosts.Add(newBlogPost);
            await _context.SaveChangesAsync();

            var newBlog = await _context.BlogPosts.Include(b => b.Author).Include(b => b.Tags).ToListAsync();
            serviceResponse.Data = _mapper.Map<GetBlogDto>(newBlogPost);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBlogDto>> DeleteBlog(int Id)
        {
            ServiceResponse<GetBlogDto> serviceResponse = new ServiceResponse<GetBlogDto>();
            BlogPost? blogPost = await _context.BlogPosts.Where(b => b.Id == Id).FirstOrDefaultAsync();
            if (blogPost == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Blog post already deleted";
                return serviceResponse;
            }
            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();

            serviceResponse.Message = "Blog post Removed";
            serviceResponse.Data = _mapper.Map<GetBlogDto>(blogPost);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBlogDto>>> GetBlogPosts()
        {
            ServiceResponse<List<GetBlogDto>> serviceResponse = new ServiceResponse<List<GetBlogDto>>();
            var blogposts = await _context.BlogPosts.Include(b => b.Author).Include(b => b.Tags).ToListAsync();
            serviceResponse.Data = blogposts.Select(blog => _mapper.Map<GetBlogDto>(blog)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBlogDto>> GetBlogPost(int Id)
        {
            ServiceResponse<GetBlogDto> serviceResponse = new ServiceResponse<GetBlogDto>();
            BlogPost? blogPost = await _context.BlogPosts.Where(b => b.Id == Id).Include(a => a.Author).Include(t => t.Tags).FirstOrDefaultAsync();
            if (blogPost == null)
            {
                serviceResponse.Message = "Blog post not found";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            serviceResponse.Data = _mapper.Map<GetBlogDto>(blogPost);
            return serviceResponse;
        }
    }
}
