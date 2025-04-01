using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Data.Common;
using Microsoft.AspNetCore.Authentication;
using System.Net;
using MassTransit;
using System;
using Jotem.Catalog.Api.Repositories;
using Jotem.Shared.ServiceResults;

namespace Jotem.Catalog.Api.Features.Categories.Create
{
    public class CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        

        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            bool existingCategory = await context.Categories.AnyAsync(x => x.Name == request.Name, cancellationToken);

            if (existingCategory)
            {
                return ServiceResult<CreateCategoryResponse>.Error(
                    HttpStatusCode.BadRequest,
                    "Category already exists",
                    $"The category name '{request.Name}' already exists");
            }

            var category = new Category
            {
                Name = request.Name,
                Id = NewId.NextSequentialGuid()
            };

            await context.Categories.AddAsync(category, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id), "<empty>");
        }
    }
}
