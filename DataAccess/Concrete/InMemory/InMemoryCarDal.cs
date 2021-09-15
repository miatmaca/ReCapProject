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

        public List<CarDetailsDto> GetBrandDetails(int brandId, int ColorId)
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

        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDto> GetChange(int brandId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpDate = _cars.SingleOrDefault(c => c.BrandId == car.BrandId);
            carToUpDate.ColorId = car.ColorId;
            carToUpDate.DailyPrice = car.DailyPrice;
            carToUpDate.Description = car.Description;
            carToUpDate.CarId = car.CarId;
            carToUpDate.ModelYear = car.ModelYear;

        }
    }
}
