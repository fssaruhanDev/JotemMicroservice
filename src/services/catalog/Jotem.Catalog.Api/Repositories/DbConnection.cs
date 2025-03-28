using Jotem.Catalog.Api.Features.Categories;
using Jotem.Catalog.Api.Features.Courses;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Reflection;

namespace Jotem.Catalog.Api.Repositories
{
    public class DbConnection(DbContextOptions<DbConnection> options) : DbContext(options)
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }


        public static DbConnection Create(IMongoDatabase database)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbConnection>().UseMongoDB(database.Client,database.DatabaseNamespace.DatabaseName);

            return new DbConnection(optionsBuilder.Options);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
