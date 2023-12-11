using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ContactUserValidator : AbstractValidator<ContactUser>
	{
		public ContactUserValidator()
		{
			RuleFor(x => x.UserName)
				.NotEmpty().WithMessage("Lütfen adınızı ve soyadınızı giriniz.")
				.MinimumLength(1).WithMessage("Ad soyad en az 3 karakter olmalıdır")
				.MaximumLength(55).WithMessage("Ad soyad en fazla 55 karakter olabilir");

			//RuleFor(x => x.UserEmail)
			//	.NotEmpty().WithMessage("Lütfen Email adresinizi giriniz.")
			//	.MaximumLength(55).WithMessage("Email en fazla 55 karakter olabilir")
			//	.EmailAddress().WithMessage("Lütfen geçerli bir Email adresi giriniz");


			RuleFor(x => x.Message)
				.NotEmpty().WithMessage("Lütfen mesajınızı giriniz.")
				.MinimumLength(1).WithMessage("Mesaj en az 1 karakter olmalıdır")
				.MaximumLength(400).WithMessage("Mesaj en fazla 400 karakter olabilir");

		}
	}
}
