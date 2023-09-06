using Core.Entities.Concrete;
using Entity.Concrete;
using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterValidator()
        {
            RuleFor(p => p.FirstName).MinimumLength(2).WithMessage("İsim En Az 2 Karakter Olmalıdır");
            RuleFor(p => p.LastName).MinimumLength(2).WithMessage("Soyisim En Az 2 Karakter Olmalıdır");
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("İsim Alanı Boş Olamaz");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyisim Alanı Boş Olamaz"); ;
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email Alanı Boş Olamaz"); ;
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre Alanı Boş Olamaz");
            



        }



    }
}
