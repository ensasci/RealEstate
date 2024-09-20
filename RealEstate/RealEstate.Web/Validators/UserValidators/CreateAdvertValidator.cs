using FluentValidation;
using RealEstate.Web.Models.User.Advert;

namespace RealEstate.Web.Validators.UserValidators
{
    public class CreateAdvertValidator : AbstractValidator<CreateOrUpdateViewModel>
    {
        public CreateAdvertValidator()
        {
            RuleFor(x => x.Title)
                .Length(10, 155).WithMessage("İlan başlığı 10 ile 55 karakter aralığında olmalıdır.");
        }
    }
}
