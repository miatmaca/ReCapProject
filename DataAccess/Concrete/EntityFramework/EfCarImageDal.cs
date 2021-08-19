using Core.DataAcces.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.DataAcces.IEntityRepository;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage,ReCapContext>,ICarImageDal
    {
       
    }
}
