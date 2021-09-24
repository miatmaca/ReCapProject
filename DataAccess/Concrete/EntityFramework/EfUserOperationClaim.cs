using Core.DataAcces.EntityFrameWork;
using Core.Entities.Entity;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfUserOperationClaim : EfEntityRepositoryBase<UserOperationClaim, ReCapContext>, IUserOperationClaimDal
    {
    }
}
