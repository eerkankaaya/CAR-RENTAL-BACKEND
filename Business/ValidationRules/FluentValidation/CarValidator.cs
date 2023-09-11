using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {

        public CarValidator() //ctor
        {
            RuleFor(p=> p.CarName).MinimumLength(2);
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(5000);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(6000).When(p => p.CarId == 2);
            RuleFor(p => p.CarName).Must(StartWithB).WithMessage("Ürünler c Harfi ile Başlasıın");
            RuleFor(p => p.CarName).Must(ContainsWtihC).WithMessage("Ürün isimleri o harfi içermeli!");




        }

        private bool StartWithB(string arg)
        {
            return arg.StartsWith("c");
        }
        private bool ContainsWtihC(string arg)
        {
            return arg.Contains("o");
        }


    }
}
