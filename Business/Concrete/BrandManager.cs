﻿using Business.Abstract;
using Business.BusinessAsbect;
using Business.Constans;
using Core.Asbect.Autofac.Caching;
using Core.Asbect.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService        
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("admin")]
        //[CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }


        //[SecuredOperation("admin")]
       // [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDelete);
        }

       // [SecuredOperation("admin")]
        public IDataResult<List<Brand>> GetAll()
        {
           return new SuccessDataResult < List < Brand >> (_brandDal.GetAll());
            
        }

        [CacheAspect]
        public IDataResult<List<Brand>> GetBrandBy(int id)
        {
            return new SuccessDataResult<List<Brand>>( _brandDal.GetAll(b=>b.BrandId==id));
        }

        //[SecuredOperation("admin")]
       // [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdate);
        }
    }
}
