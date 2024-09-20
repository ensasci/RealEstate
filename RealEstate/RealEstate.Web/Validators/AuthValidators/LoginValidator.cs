using FluentValidation;
using RealEstate.Web.Models.Auth;

namespace RealEstate.Web.Validators.AuthValidators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email alanı boş olamaz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email doğru formatta değil");
            RuleFor(x => x.Password)
                .NotNull().WithMessage("Şifre boş geçilemez")
                .MinimumLength(6).WithMessage("Şife minimum 6 karakter olmalı");
        }
    }
}
