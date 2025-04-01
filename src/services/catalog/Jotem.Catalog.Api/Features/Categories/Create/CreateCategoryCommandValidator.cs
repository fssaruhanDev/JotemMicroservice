using FluentValidation;

namespace Jotem.Catalog.Api.Features.Categories.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot empty")
                .Length(4,25).WithMessage("{PropertyName} must be betweem 4 and 25 characters ");
        }
    }
}
