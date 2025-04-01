using Jotem.Catalog.Api.Features.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Reflection.Emit;

namespace Jotem.Catalog.Api.Repositories
{
    public class CategoryEntityConnection : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.ToCollection("categories");
            builder.HasKey(id => id.Id);
            builder.Property(id => id.Id).ValueGeneratedNever();
            builder.Property(id => id.Name).HasElementName("name").HasMaxLength(100);
            builder.Ignore(id => id.Courses);

        }
    }
}
