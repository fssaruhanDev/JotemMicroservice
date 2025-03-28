using Jotem.Shared;
using MediatR;

namespace Jotem.Catalog.Api.Features.Categories.Create
{
    public record CreateCategoryCommand(string Name) : IRequest<ServiceResult<CreateCategoryResponse>>;
    
}
