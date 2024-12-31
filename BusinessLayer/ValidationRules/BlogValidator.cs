using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle)
                .NotEmpty().WithMessage("Blog başlığı kısmı boş geçilemez.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.BlogTitle)
                        .MinimumLength(2).WithMessage("Blog başlığı kısmı en az 2 karakter olmalıdır.")
                        .MaximumLength(50).WithMessage("Blog başlığı kısmı en fazla 50 karakter olmalıdır.");
                });

            RuleFor(x => x.BlogContent)
           .NotEmpty().WithMessage("Blog içerigi kısmı boş geçilemez.")
           .DependentRules(() =>
           {
               RuleFor(x => x.BlogContent)
                   .MinimumLength(130).WithMessage("Blog içerigi kısmı en az 130 karakter olmalıdır.")
                   .MaximumLength(2000).WithMessage("Blog başlığı kısmı en fazla 2000 karakter olmalıdır.");

           });
            RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Kategori İsmi Seçiniz") // Kategori seçilmemişse hata verir
            .When(x => x.CategoryId == null || x.CategoryId == 0) // Eğer kategori boşsa veya '0' ise hata verir
            .WithMessage("Kategori İsmi Seçiniz");


        }
    }
}
