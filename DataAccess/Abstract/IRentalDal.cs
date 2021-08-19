using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.DataAcces.IEntityRepository;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
    }
}
