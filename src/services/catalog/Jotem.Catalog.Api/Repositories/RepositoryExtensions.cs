using Jotem.Catalog.Api.Options;
using MongoDB.Driver;

namespace Jotem.Catalog.Api.Repositories
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositoryOptions(this IServiceCollection services)
        {

            services.AddSingleton<IMongoClient>(sp =>
            {
                var options = sp.GetRequiredService<MongoOptions>();
                return new MongoClient(options.ConnectionString);
            });

            services.AddScoped(sp =>
            {
                var options = sp.GetRequiredService<MongoOptions>();
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(options.Database);
            });
            return services;
        }
    }
}
