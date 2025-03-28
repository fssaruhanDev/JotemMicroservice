using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jotem.Catalog.Api.Features.Categories.Create
{
    public static class CreateCategoryEndpoint
    {


        public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group
                .MapPost("/", async (CreateCategoryCommand request, IMediator mediator) =>
                {
                    var result = await mediator.Send(request);
                    return new ObjectResult(result)
                    {
                        StatusCode = result.StatusCode.GetHashCode(),
                    };
                });

            return group;
        }



    }
}
