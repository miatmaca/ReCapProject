using Business.Abstract;
using Business.BusinessAsbect;
using Business.Constans;
using Core.Asbect.Autofac.Caching;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImage)
        {
            _carImageDal = carImage;

        }

        [SecuredOperation("admin")]
        [CacheAspect]
        public IResult Add(IFormFile file, CarImage carImage)
        {

            IResult result = BusinessRules.Run(ImageFull(carImage));

            if (result != null)
            {
                return result;
            }

            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult("İmage Error");
            }

            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);

        }

        [CacheRemoveAspect("ICarImageService")]
        public IResult Delete(CarImage carImage)
        {
            var result = _carImageDal.Get(c => c.CarId == carImage.CarId);
            if (result == null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }

            //FileHelper.Delete(result.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<CarImage> Get(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == Id));

        }
        public IDataResult<List<CarImage>> GetById(int Id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(Id));

            if (result!=null)
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == Id));
            }

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(Id).Data);

        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {

            if (carImage == null)
            {
                return new ErrorResult(Messages.NotFound);
            }

            var updateFile = FileHelper.Update(file, carImage.ImagePath);
            if (!updateFile.Success)
            {
                return new ErrorResult(updateFile.Message);
            }

            carImage.ImagePath = updateFile.Message;

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.Update);
        }


        private IResult ImageFull(CarImage carImage)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.Imagefull);
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> CheckIfCarImageNull(int Id)
        {
            string path = @"\images\Logo.png";

            var result = _carImageDal.GetAll(c => c.CarId == Id).Any();
            if (!result)
            {
                List<CarImage> carImage = new List<CarImage>();
                carImage.Add(new CarImage { CarId = Id, Date = DateTime.Now, ImagePath = path });
                return new SuccessDataResult<List<CarImage>>(carImage);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == Id).ToList());
            
             

           
        }

    }
}
