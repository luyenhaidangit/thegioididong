using FluentValidation;
using Thegioididong.Api.Enums.Common;
using Thegioididong.Api.Models.Ecommerce.ProductCategory;

namespace Thegioididong.Api.Validators.Ecommerce.ProductCategory
{
    public class CreateProductCategoryRequestValidator : AbstractValidator<CreateProductCategoryRequest>
    {
        public CreateProductCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(x => x.Slug)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(x => x.Description)
                .MaximumLength(100000);

            RuleFor(x => x.Image)
                .MaximumLength(255);

            RuleFor(x => x.Order)
                .InclusiveBetween(0, 127);

            RuleFor(x => x.Icon)
                .MaximumLength(50);

            RuleFor(x => x.IconImage)
                .MaximumLength(255);

            RuleFor(x => x.IsFeatured)
                .Must(x => x == true || x == false);

            RuleFor(x => x.Status)
                .Must(status => Enum.IsDefined(typeof(BaseStatusEnum), status));
        }
    }
}
