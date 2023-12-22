using EntityLayer.Concrete;
using FluentValidation;


namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Lütfen başlık giriniz.")
            .MinimumLength(1).WithMessage("Ad soyad en az 1 karakter olmalıdır")
            .MaximumLength(150).WithMessage("Ad soyad en fazla 150 karakter olabilir");

            RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Lütfen kategori giriniz.");

            RuleFor(x => x.MainImage)
            .NotEmpty().WithMessage("Lütfen görsel yükleyiniz");

        }
    }
}
