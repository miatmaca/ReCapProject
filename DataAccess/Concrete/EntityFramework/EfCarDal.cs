using Core.DataAcces.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join cı in context.CarImages
                             on c.CarId equals cı.CarId
                             //join ci in context.CarImages
                             //on c.Id equals ci.Id
                             select new CarDetailsDto
                             {
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 BrandName = b.BrandName,
                                 Description = c.Description,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 ImagePath = cı.ImagePath,
                                 CarId = c.CarId



                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }


        }


    }
}
