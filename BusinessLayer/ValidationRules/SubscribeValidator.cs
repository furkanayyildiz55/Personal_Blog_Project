using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
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
        SubscribeManager SubscribeManager = new SubscribeManager(new EfSubscribeRepository());

        public SubscribeValidator()
		{
			RuleFor(x => x.SubscribeEmail)
				.NotEmpty().WithMessage("Lütfen Email adresinizi giriniz.")
				.MaximumLength(55).WithMessage("Email en fazla 55 karakter olabilir")
				.EmailAddress().WithMessage("Lütfen geçerli bir Email adresi giriniz");

            RuleFor(x => x.SubscribeEmail)
                   .Must(BeUniqueEmail).WithMessage("Email bültene kayıtlı");

        }

        private bool BeUniqueEmail(string? Email)
        {
            Subscribe subscribe = new Subscribe();
            subscribe = SubscribeManager.Get(s => s.SubscribeEmail == Email);
            return subscribe == null;
        }
    }
}
