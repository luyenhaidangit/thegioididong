using FluentValidation;
using Thegioididong.Api.Models.Requests;

namespace Thegioididong.Api.Validators.Common
{
    public class EntityIdentityRequestValidator<T> : AbstractValidator<EntityIdentityRequest<T>>
    {
        public EntityIdentityRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
