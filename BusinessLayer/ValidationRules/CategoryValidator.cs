using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
           RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori İsmi Boş Geçilemez");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori İsmi 50 Karekterden Fazla Olamaz!");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori İsmi  2 Karekterden Az Olamaz!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori İçeriği Boş Geçilemez");
            RuleFor(x => x.CategoryDescription).MaximumLength(50).WithMessage("Kategori İçeriği 50 Karekterden Fazla Olamaz!");
            RuleFor(x => x.CategoryDescription).MinimumLength(2).WithMessage("Kategori İçeriği 2 Karekterden Az Olamaz!");

        }
    }
}
