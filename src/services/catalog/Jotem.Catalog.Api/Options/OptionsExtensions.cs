using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Jotem.Catalog.Api.Options
{
    public static class OptionsExtensions
    {


        public static IServiceCollection AddMongoOptions(this IServiceCollection services)
        {
            services.AddOptions<MongoOptions>().BindConfiguration(nameof(MongoOptions)).ValidateDataAnnotations().ValidateOnStart();

            services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoOptions>>().Value);

            return services;
        }

    }
}
