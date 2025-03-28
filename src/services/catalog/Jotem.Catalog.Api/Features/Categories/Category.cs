using Jotem.Catalog.Api.Features.Courses;
using Jotem.Catalog.Api.Repositories;

namespace Jotem.Catalog.Api.Features.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;

        public List<Course>? Courses { get; set; }
    }
}
