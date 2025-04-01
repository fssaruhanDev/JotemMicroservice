using Asp.Versioning.Builder;
using Jotem.Catalog.Api.Features.Categories.Create;
using Jotem.Catalog.Api.Features.Categories.GetAll;

namespace Jotem.Catalog.Api.Features.Categories
{
    public static class CategoryEndpointExt
    {

        public static void AddCategoryGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/categories").WithTags("Categories")
                .WithApiVersionSet(apiVersionSet)
                .CreateCategoryGroupItemEndpoint()
                .GetAllCategoryGroupItemEndpoint();
        }

    }
}
