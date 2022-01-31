using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.categoryName).NotEmpty().WithMessage("kategori adını boş geçemezsiniz");
            RuleFor(x => x.categoryDescription).NotEmpty().WithMessage("açıklamayı boş geçemezsiniz");
            RuleFor(x => x.categoryName).MinimumLength(3).WithMessage("en az üç karakter giriniz");
            RuleFor(x => x.categoryName).MaximumLength(20).WithMessage("lütfen en fazla 20 karakter giriniz");
        }
    }
}
