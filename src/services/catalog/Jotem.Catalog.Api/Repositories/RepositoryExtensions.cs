using Jotem.Catalog.Api.Options;
using MongoDB.Driver;

namespace Jotem.Catalog.Api.Repositories
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddDatabaseOptionsExt(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var options = sp.GetRequiredService<MongoOption>();
                return new MongoClient(options.ConnectionString);
            });

            services.AddScoped(sp =>
            {
                var mongoClient = sp.GetRequiredService<IMongoClient>();
                var options = sp.GetRequiredService<MongoOption>();

                return AppDbContext.Create(mongoClient.GetDatabase(options.DatabaseName));
            });


            return services;
        }
    }
}
