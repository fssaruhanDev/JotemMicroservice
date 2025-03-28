using Jotem.Catalog.Api.Features.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Reflection.Emit;

namespace Jotem.Catalog.Api.Repositories
{
    public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToCollection("courses");
            builder.HasKey(id => id.Id);
            builder.Property(id => id.Id).ValueGeneratedNever();
            builder.Property(id => id.Name).HasElementName("name").HasMaxLength(100);
            builder.Property(id => id.Description).HasElementName("description");
            builder.Property(id => id.ImageUrl).HasElementName("imageUrl");
            builder.Property(id => id.Price).HasElementName("price");
            builder.Property(id => id.UserId).HasElementName("userId");
            builder.Property(id => id.CreatedDate).HasElementName("createdDate");
            builder.Property(id => id.CategoryId).HasElementName("categoryId");
            builder.Ignore(id => id.Category);

            builder.OwnsOne(c => c.Feature, feature =>
            {
                feature.Property(x => x.Duration).HasElementName("duration");
                feature.Property(x => x.Raiting).HasElementName("raiting");
                feature.Property(x => x.EducatorFullName).HasElementName("educatorFullName").HasMaxLength(100);
            });
        }
    }
}
