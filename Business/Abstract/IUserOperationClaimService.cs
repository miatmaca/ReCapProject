using Core.Entities.Entity;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public interface IUserOperationClaimService
    {
       
        IResult Add(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim  userOperationClaim);
        IResult Delete(UserOperationClaim userOperationClaim);
        IDataResult<List<UserOperationClaim>> GetAll();
        IDataResult<UserOperationClaim> GetClaimByUserId(int userId);

    }
}
