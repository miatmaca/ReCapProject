using Core.Entities.Entity;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.DataAcces.IEntityRepository;

namespace DataAccess.Abstract
{
   public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
