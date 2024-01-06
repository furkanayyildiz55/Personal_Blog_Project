using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;


namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
		BlogManager BlogManager = new BlogManager(new EfBlogRepository());

		public BlogValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Lütfen başlık giriniz.")
            .MinimumLength(1).WithMessage("Başlık en az 1 karakter olmalıdır")
            .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir");

            RuleFor(x => x.UrlTitle)
            .NotEmpty().WithMessage("Blog için link oluşturulamadı");

            RuleFor(x => x.UrlTitle)
            .Must(BeUniqueBlog).WithMessage("Bu isimde blog bulunmaktadır")
            .When(x => x.ObjectId == 0);


            RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Lütfen kategori giriniz.");

        }

		private bool BeUniqueBlog(string? UrlTitle)
		{
			Blog blog = new Blog();
            blog = BlogManager.Get(b => b.UrlTitle == UrlTitle);
            return blog == null;
		}
	}
}
