using AutoMapper;
using Jotem.Catalog.Api.Features.Courses;
using Jotem.Catalog.Api.Features.Courses.Create;
using Jotem.Catalog.Api.Features.Courses.Dtos;

namespace Jotem.Catalog.Api.Features.Courses
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
}