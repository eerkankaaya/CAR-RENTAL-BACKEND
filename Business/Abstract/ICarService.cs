using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {


        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(string car );
        IDataResult<List<ColorDetailDto>> GetColorDetails();
        IDataResult<List<BrandDetailDto>> GetBrandDetails();
        IResult AddTransactionalTest(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult <List<CustomerDetailDto>> GetCustomerDetails();
    }
}
