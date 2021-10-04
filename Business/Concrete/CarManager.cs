using Business.Abstract;
using Business.BusinessAsbect;
using Business.Constans;
using Business.Validation.FluentValidation;
using Core.Asbect.Autofac.Caching;
using Core.Asbect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{

    public class CarManager : ICarService
    {
        ICarDal _carDal1;
        public CarManager(ICarDal carDal)
        {
            _carDal1 = carDal;

        }

         [SecuredOperation("admin")]
         [ValidationAspect(typeof(CarValidator))]//Add metodu doğrula .CarValidator deki kurallara göre
         [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            // ValidationTool.Validate(new CarValidator(), car);
            
          
                _carDal1.Add(car);
                return new SuccessResult(Messages.CarAdded);
            
        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(Car car)
        {
            _carDal1.Delete(car);
            return new SuccessResult(Messages.CarDelete);
        }

        //  [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal1.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal1.GetAll(p => p.BrandId == id));

        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal1.GetAll(p => p.ColorId == id));
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal1.GetAll(), Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal1.GetCarDetails(), Messages.Listed);
        }
        public IDataResult<List<CarDetailsDto>> GetFilter(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal1.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId), Messages.Listed);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal1.GetCarDetails(c => c.BrandId == brandId), Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetImageByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal1.GetCarDetails(c => c.ColorId == colorId), Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailsDto>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal1.GetCarDetails(c => c.CarId == carId), Messages.Listed);
        }
    }
}
