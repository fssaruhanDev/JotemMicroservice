using Asp.Versioning.Builder;
using Jotem.Catalog.Api.Features.Courses.Create;
using Jotem.Catalog.Api.Features.Courses.Delete;
using Jotem.Catalog.Api.Features.Courses.GetAll;
using Jotem.Catalog.Api.Features.Courses.GetAllByUserId;
using Jotem.Catalog.Api.Features.Courses.GetById;
using Jotem.Catalog.Api.Features.Courses.Update;

namespace Jotem.Catalog.Api.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/courses").WithTags("Courses").WithApiVersionSet(apiVersionSet)
                .CreateCourseGroupItemEndpoint()
                .GetAllCourseGroupItemEndpoint()
                .GetByIdCourseGroupItemEndpoint()
                .UpdateCourseGroupItemEndpoint()
                .DeleteCourseGroupItemEndpoint()
                .GetByUserIdCourseGroupItemEndpoint();
        }
    }
}