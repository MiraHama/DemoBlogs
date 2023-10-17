using AutoMapper;
using Blogging.Data;
using Blogging.DTOs;
using Blogging.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Services
{
    public class AuthorService : IAuthorService
    {
        public readonly DataContext _context;
        private readonly IMapper _mapper;
        public AuthorService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetAuthorDto>> CreateAuthor(AuthorDto author)
        {
            ServiceResponse<GetAuthorDto> serviceResponse = new ServiceResponse<GetAuthorDto>();
            Author? existingAuthor = await _context.Authors.Where(x => x.Name == author.Name).Include(b => b.Posts).ThenInclude(p => p.Tags).FirstOrDefaultAsync();
            if (existingAuthor != null)
            {
                serviceResponse.Message = "Author already exists";
                serviceResponse.Success = false;
                serviceResponse.Data = _mapper.Map<GetAuthorDto>(existingAuthor); 
                return serviceResponse;
            }
            Author newAuthor = new Author() { Name = author.Name };
            AuthorValidator validator = new AuthorValidator();
            ValidationResult results = validator.Validate(newAuthor);
            if (!results.IsValid)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = results.ToString(", ");
                return serviceResponse;
            }

            _context.Authors.Add(newAuthor);
            await _context.SaveChangesAsync();

            var createdAuthor = _context.Authors.Where(x => x.Name == author.Name).Include(b => b.Posts).ThenInclude(p => p.Tags).FirstOrDefault();

            serviceResponse.Data = _mapper.Map<GetAuthorDto>(newAuthor);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAuthorDto>> DeleteAuthor(int Id)
        {
            ServiceResponse<GetAuthorDto> serviceResponse = new ServiceResponse<GetAuthorDto>();
            Author? author = await _context.Authors.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (author == null)
            {
                serviceResponse.Success = false;
                return serviceResponse;
            }
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetAuthorDto>(author);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAuthorDto>> GetAuthor(int Id)
        {
            ServiceResponse<GetAuthorDto> serviceResponse = new ServiceResponse<GetAuthorDto>();
            Author? author = await _context.Authors.Where(a => a.Id == Id).Include(a => a.Posts).ThenInclude(p => p.Tags).FirstOrDefaultAsync();
            if (author == null)
            {
                serviceResponse.Success = false;
                return serviceResponse;
            }
            serviceResponse.Data = _mapper.Map<GetAuthorDto>(author);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAuthorDto>>> GetAuthors()
        {
            ServiceResponse<List<GetAuthorDto>> serviceResponse = new ServiceResponse<List<GetAuthorDto>>();
            var authors = await _context.Authors.Include(a => a.Posts).ThenInclude(p => p.Tags).ToListAsync();
            serviceResponse.Data = authors.Select(author => _mapper.Map<GetAuthorDto>(author)).ToList();
            return serviceResponse;
        }
    }
}
