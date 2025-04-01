using AutoMapper;
using Jotem.Catalog.Api.Features.Dtos;

namespace Jotem.Catalog.Api.Features.Categories
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
