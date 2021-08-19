using Business.Abstract;
using Business.Constans;
using Business.Validation.FluentValidation;
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
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(),car);
                
            _carDal1.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

       public IResult Delete(Car car)
        {
            _carDal1.Delete(car);
            return new SuccessResult(Messages.CarDelete);
        }                           
       public IResult Update(Car car)
        {
             _carDal1.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal1.GetAll(p=>p.BrandId==id));
       }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal1.GetAll(p=>p.ColorId==id));
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>( _carDal1.GetAll());        
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            
                return new SuccessDataResult<List<CarDetailsDto>>(_carDal1.GetCarDetails(),Messages.Listed);
            
        }
    }
}
