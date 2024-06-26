﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
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
    //[SecuredOperation("Admin")]
    //[ValidationAspect(typeof(CarValidator))]
    [PerformanceAspect(5)]
    public class CarManager : ICarService
    {

        ICarDal _carDal;
        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfCarIdCorrect(car.CarId),
                CheckIfCarNameExists(car.CarName));

            if (result != null)
            {
                return result;

            }
           _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        
        
        //[CacheRemoveAspect("ICarService.Get")]
        public IDataResult<Car> Get(string car)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarName == car));
        }

        
        
        
        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }



        //[CacheRemoveAspect("ICarService.GetAll")]
       //[CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        
        
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }


        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }

        

        

        
        
        private IResult CheckIfCarCountOfCarIdCorrect(int carId)
        {

            var result = _carDal.GetAll(p => p.CarId == carId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.CarCountError);

            }
            return new SuccessResult();

        }

        private IResult CheckIfCarNameExists(string carName)
        {

            var result = _carDal.GetAll(p => p.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);

            }
            return new SuccessResult();

        }

        
    }
}
