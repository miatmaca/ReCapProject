using Core.Entities.Entity;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.DataAcces.IEntityRepository;

namespace DataAccess.Abstract
{
   public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        List<OperationClaim> GetUserClaimById(int userId);
        List<OperationClaim> GetAllUserClaim();
        List<UserClaimDto> GetAllUsersDetail();
    }
}
