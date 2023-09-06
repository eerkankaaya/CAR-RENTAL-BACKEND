using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForLoginValidator : AbstractValidator<UserForLoginDto>
    {
        public UserForLoginValidator()
        {
            RuleFor(p => p.Email).MinimumLength(2).WithMessage("İsim En Az 2 Karakter Olmalıdır");
            RuleFor(p => p.Password).MinimumLength(2).WithMessage("Soyisim En Az 2 Karakter Olmalıdır");
            
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email Alanı Boş Olamaz"); ;
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre Alanı Boş Olamaz");




        }



    }
}
