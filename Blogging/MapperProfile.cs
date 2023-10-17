using AutoMapper;
using Blogging.DTOs;
using Blogging.Models;

namespace Blogging
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        { 
            CreateMap<Author, GetAuthorDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<BlogDto, BlogPost>().ReverseMap();
            CreateMap<GetBlogDto, BlogPost>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();

        }
    }
}
