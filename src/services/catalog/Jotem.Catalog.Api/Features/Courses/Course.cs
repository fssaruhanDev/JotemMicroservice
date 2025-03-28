using Jotem.Catalog.Api.Features.Categories;
using Jotem.Catalog.Api.Repositories;

namespace Jotem.Catalog.Api.Features.Courses
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public Guid UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = default!;


        public Feature Feature { get; set; } = default!;

    }
}
