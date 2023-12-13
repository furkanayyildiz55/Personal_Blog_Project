using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class SubscribeValidator : AbstractValidator<Subscribe>
	{
		public SubscribeValidator()
		{


			RuleFor(x => x.SubscribeEmail)
				.NotEmpty().WithMessage("Lütfen Email adresinizi giriniz.")
				.MaximumLength(55).WithMessage("Email en fazla 55 karakter olabilir")
				.EmailAddress().WithMessage("Lütfen geçerli bir Email adresi giriniz");


		}
	}
}
