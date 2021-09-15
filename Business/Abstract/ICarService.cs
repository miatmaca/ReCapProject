using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface ICarService
    {
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<CarDetailsDto>> GetByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetImageByColorId(int colorId);
        IDataResult<List<CarDetailsDto>> GetFilter(int brandId, int colorId);
        public IDataResult<List<CarDetailsDto>> GetByCarId(int carId);




    }
}
