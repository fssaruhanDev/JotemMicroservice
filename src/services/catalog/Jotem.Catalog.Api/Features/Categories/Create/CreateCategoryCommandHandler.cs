using Jotem.Shared;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Data.Common;
using Microsoft.AspNetCore.Authentication;
using System.Net;
using MassTransit;

namespace Jotem.Catalog.Api.Features.Categories.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        private readonly DbContext _context;

        public CreateCategoryCommandHandler(DbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingCategory = await _context.Set<Category>().AnyAsync(x => x.Name == request.Name, cancellationToken);

            // Additional logic to handle the creation of the category
            if (existingCategory)
            {
                return ServiceResult<CreateCategoryResponse>.Error(HttpStatusCode.BadRequest,"Category already exists",$"The category name '{request.Name}' allready exsist");
            }



            var category = new Category
            {
              Name = request.Name,
            };
            category.Id = NewId.NextSequentialGuid();
            await _context.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);


            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id),"<empty>");
        }
    }
}
