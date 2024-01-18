using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class LoginValidator  : AbstractValidator<Writer>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Lütfen Email adresinizi giriniz.")
               .MaximumLength(55).WithMessage("Email en fazla 55 karakter olabilir")
               .EmailAddress().WithMessage("Lütfen geçerli bir Email adresi giriniz");

            RuleFor(x => x.Password)
              .NotEmpty().WithMessage("Lütfen şifrenizi giriniz.")
              .MinimumLength(5).WithMessage("Şifre en az 5 karakter olabilir")
              .MaximumLength(55).WithMessage("Şifre en fazla 55 karakter olabilir");
        }
    }
}
