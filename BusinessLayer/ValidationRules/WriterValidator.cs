using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.writerName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(x => x.writerSurName).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.writerAbout).NotEmpty().WithMessage("hakkımda kısmını boş geçemezsiniz");
            RuleFor(x => x.writerTitle).NotEmpty().WithMessage("unvan kısmını boş geçemezsiniz");
            RuleFor(x => x.writerSurName).MinimumLength(3).WithMessage("lütfen en az 3 karakter giriniz");
            RuleFor(x => x.writerSurName).MaximumLength(50).WithMessage("lütfen en fazla 50 karakter giriniz");
        }
    }
}
