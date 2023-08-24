using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {


        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);

            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<Car> Get(string car)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarName == car));
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }


            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult <List<BrandDetailDto>> GetBrandDetails()
        {
            return new SuccessDataResult<List<BrandDetailDto>>(_carDal.GetBrandDetails());
        }
    


        public IDataResult<List<ColorDetailDto>> GetColorDetails()
        {
            return new SuccessDataResult<List<ColorDetailDto>>(_carDal.GetColorDetails());
        }

        public IResult Update(Car car )
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
