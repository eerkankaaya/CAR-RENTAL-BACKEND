using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<ColorDetailDto> GetColorDetails();
        List<BrandDetailDto> GetBrandDetails();
        List<CarDetailDto> GetCarDetails();
        List<RentalDetailDto> GetRentalDetails();
        List<CustomerDetailDto> GetCustomerDetails();
    }
}
