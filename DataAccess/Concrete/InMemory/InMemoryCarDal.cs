using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal : ICarDal
    { 
        List<Car> _cars;
       
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            new Car {BrandId=1,DailyPrice=200,ColorId=120,Description="Suv",Id=1,ModelYear=1995 },
            new Car {BrandId=2,DailyPrice=100,ColorId=234,Description="Jeep",Id=2,ModelYear=2008 },
            new Car {BrandId=3,DailyPrice=300,ColorId=345,Description="Otomobil",Id=3,ModelYear=2004 },
            new Car {BrandId=4,DailyPrice=500,ColorId=129,Description="Kamyonet",Id=4,ModelYear=2021 }
            };

            




        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete= _cars.SingleOrDefault(c=>c.BrandId==car.BrandId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int categoryId)
        {
            return _cars.Where(c=>c.BrandId==categoryId).ToList();
           

        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpDate = _cars.SingleOrDefault(c => c.BrandId == car.BrandId);
            carToUpDate.ColorId = car.ColorId;
            carToUpDate.DailyPrice = car.DailyPrice;
            carToUpDate.Description = car.Description;
            carToUpDate.Id = car.Id;
            carToUpDate.ModelYear = car.ModelYear;

        }
    }
}
