using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using static Core.DataAcces.IEntityRepository;

namespace DataAccess.Abstract
{
  public interface IPaymentDal:IEntityRepository<Payment>
    {
        List<RentalDto> GetPaymentDetails(Expression<Func<RentalDto, bool>> filter = null);
    }
}
