using Jotem.Catalog.Api.Features.Categories.Create;

namespace Jotem.Catalog.Api.Features.Categories
{
    public static class CategoryEndpointExt
    {

        public static void AddCategoryEntpointGroupExt(this WebApplication app)
        {
            app.MapGroup("api/categories").CreateCategoryGroupItemEndpoint();
        }

    }
}
