using Business.Abstract;
using Business.Constans;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Car car)
        {
           if (car.Description.Length>=2 && car.DailyPrice>0)
            {
                _carDal1.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
           else
            {
                Console.WriteLine("Bilgileri Kontrol Ediniz");
                return new ErrorResult(Messages.ErrorMessage);
            }
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
            
                return new SuccessDataResult<List<CarDetailsDto>>(_carDal1.GetCarDetails());
            
        }
    }
}
