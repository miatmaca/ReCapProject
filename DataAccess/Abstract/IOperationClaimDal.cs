using Core.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.DataAcces.IEntityRepository;

namespace DataAccess.Abstract
{
    public interface IOperationClaimDal:IEntityRepository<OperationClaim>
    {
    }
}
