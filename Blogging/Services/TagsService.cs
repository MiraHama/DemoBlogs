using AutoMapper;
using Blogging.Data;
using Blogging.DTOs;
using Blogging.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Services
{
    public class TagsService : ITagsService
    {
        public readonly DataContext _context;
        public readonly IMapper _mapper;
        public TagsService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<TagDto>> CreateTag(TagDto tagToAdd)
        {
            ServiceResponse<TagDto> serviceResponse = new ServiceResponse<TagDto>();
            Tag? tag = await _context.Tags.Where(t => t.Name == tagToAdd.Name).FirstOrDefaultAsync();
            if (tag != null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Tag already exists";
                return serviceResponse;
            }

            Tag newTag = new Tag() { Name = tagToAdd.Name };
            TagValidator validator = new TagValidator();
            ValidationResult results = validator.Validate(newTag);
            if (!results.IsValid)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = results.ToString(", ");
                return serviceResponse;
            }
            _context.Tags.Add(newTag);
            await _context.SaveChangesAsync();

            var createdTag = await _context.Tags.Where(t => t.Name == tagToAdd.Name).FirstOrDefaultAsync();
            serviceResponse.Data = _mapper.Map<TagDto>(createdTag);
            return serviceResponse;
        }

        public async Task<ServiceResponse<TagDto>> GetTag(int Id)
        {
            ServiceResponse<TagDto> serviceResponse = new ServiceResponse<TagDto>();
            Tag? tag = await _context.Tags.Where(t => t.Id == Id).FirstOrDefaultAsync();
            if (tag == null)
            {
                serviceResponse.Message = "Tag not found";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            serviceResponse.Data = _mapper.Map<TagDto>(tag);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TagDto>>> GetTags()
        {
            ServiceResponse<List<TagDto>> serviceResponse = new ServiceResponse<List<TagDto>>();
            var tags = await _context.Tags.ToListAsync();
            serviceResponse.Data = tags.Select(tag => _mapper.Map<TagDto>(tag)).ToList();
            return serviceResponse;
        }
    }
}
