using Jotem.Shared.Interfaces;
using Jotem.Shared.ServiceResults;
using MediatR;

namespace Jotem.Catalog.Api.Features.Categories.Create
{
    public record CreateCategoryCommand(string Name) : IRequestByServiceResult<CreateCategoryResponse>;
    
}
