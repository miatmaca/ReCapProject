using Business.Abstract;
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

        public void Add(Car car)
        {
           if (car.Description.Length>=2 && car.DailyPrice>0)
            {
                _carDal1.Add(car);
            }
           else
            {
                Console.WriteLine("Bilgileri Kontrol Ediniz");
            }
        }

        public void Delete(Car car)
        {
            _carDal1.Delete(car);
        }                           
        public void Update(Car car)
        {
            _carDal1.Update(car);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal1.GetAll(p=>p.BrandId==id);
       }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal1.GetAll(p=>p.ColorId==id);
        }

        public List<Car> GetAll()
        {
            return _carDal1.GetAll();        
        }

        public List<CarDetailsDto> GetCarDetails()
        {
          return   _carDal1.GetCarDetails();
        }
    }
}
