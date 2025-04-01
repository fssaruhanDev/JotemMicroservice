using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Jotem.Catalog.Api.Options
{
    public static class OptionsExtensions
    {


        public static IServiceCollection AddMongoOptionsExt(this IServiceCollection services)
        {
            services.AddOptions<MongoOption>().BindConfiguration(nameof(MongoOption)).ValidateDataAnnotations().ValidateOnStart();

            services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoOption>>().Value);

            return services;
        }

    }
}
