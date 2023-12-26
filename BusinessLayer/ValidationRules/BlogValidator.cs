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
            .MinimumLength(1).WithMessage("Başlık en az 1 karakter olmalıdır")
            .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir");

            RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Lütfen kategori giriniz.");

            RuleFor(x => x.MainImage)
            .NotEmpty().WithMessage("Lütfen görsel yükleyiniz");

        }
    }
}
