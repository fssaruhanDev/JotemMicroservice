using Jotem.Shared.Extensions;
using MediatR;

namespace Jotem.Catalog.Api.Features.Categories.GetAll
{
    public static class GetAllCategoriesEndpoint
    {
        public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/",
                    async (IMediator mediator) =>
                    {
                        var result = await mediator.Send(new GetAllCategoriesQuery());
                        return result.ToResult();
                    });


            return group;
        }
    }
}