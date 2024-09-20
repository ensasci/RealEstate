using FluentValidation;
using RealEstate.Web.Models.Auth;

namespace RealEstate.Web.Validators.AuthValidators
{
	public class SignUpValidator:AbstractValidator<SignUpViewModel>
	{
        public SignUpValidator()
        {
			RuleFor(x => x.FullName)
			  .Length(7, 30).WithMessage("Ad soyad en az 7 en fazla 30 karakter olmalı");

			RuleFor(x => x.Email)
				.Length(12, 50).WithMessage("Email adresi en az 15 en fazla 55 karakter olmalı")
				.EmailAddress().WithMessage("Email adresi doğru formatta değil");

			RuleFor(x => x.Phone)
				.Length(11).WithMessage("Telefon 11 karakter olmalıdır");

			RuleFor(x => x.Password)
				.MinimumLength(6).WithMessage("Parola en az 6 karakter olmalı");
		}
    }
}
