using Core.Utilities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carId);
        IResult Update(IFormFile file,CarImage carImage);
        IDataResult<List<CarImage>> GetById(int Id);
        IDataResult <List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int Id);
       
    }
}
