using Business.Abstract;
using Business.Constans;
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

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
           _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDelete);
        }
        public IDataResult<List<CarDetailsDto>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_colorDal.GetCarDetails(c => c.ColorId == colorId), Messages.Listed);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>( _colorDal.GetAll());
        }

        public IDataResult<List<Color>> GetColorId(int id)
        {
           
            if (id == 1)
            {
                return new ErrorDataResult<List<Color>>(Messages.ErrorMessage);
            }
            else
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == id));
            }

            }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdate);
        }
    }
}
