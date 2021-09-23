using Business.Abstract;
using Business.BusinessAsbect;
using Business.Constans;
using Core.Asbect.Autofac.Caching;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal carDal)
        {
            _colorDal = carDal;

        }
       // [SecuredOperation("admin")]
       // [CacheRemoveAspect("IColorService.Get")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }
      //  [SecuredOperation("admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDelete);
        }
        public IDataResult<List<CarDetailsDto>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_colorDal.GetCarDetails(c => c.ColorId == colorId), Messages.Listed);
        }
       // [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<Color>> GetColorId(int id)
        {

            
           
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == id));
          

        }
       // [SecuredOperation("admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdate);
        }
    }
}
