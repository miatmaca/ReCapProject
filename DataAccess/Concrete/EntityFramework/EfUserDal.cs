using Core.DataAcces.EntityFrameWork;
using Core.Entities.Entity;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<OperationClaim> GetAllUserClaim()
        {
            using (var context =new ReCapContext())
            {
                return context.Set<OperationClaim>().ToList();
                   
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from oc in context.OperationClaims
                             join uc in context.UserOperationClaims
                             on oc.Id equals uc.OperationClaimsId
                             where uc.UserId == user.Id
                             select new OperationClaim { Id = oc.Id, Name = oc.Name };
                return result.ToList();

            }
        }
        public List<OperationClaim> GetUserClaimById(int userId)
        {
            using (var context = new ReCapContext())
            {
                var result = from oC in context.OperationClaims
                             join uC in context.UserOperationClaims
                                 on oC.Id equals uC.OperationClaimsId
                             where uC.UserId == userId
                             select new OperationClaim { Id = oC.Id, Name = oC.Name };
                return result.ToList();
            }
        }
        public List<UserClaimDto> GetAllUsersDetail()
        {
            using (var context = new ReCapContext())
            {
                var result = from userOperationClaim in context.UserOperationClaims
                             join user in context.Users
                             on userOperationClaim.UserId equals user.Id
                             join operationClaim in context.OperationClaims
                             on userOperationClaim.OperationClaimsId equals operationClaim.Id
                             select new UserClaimDto {
                                 firstName = user.FirstName,
                                 lastName=user.LastName,
                                 email=user.Email,
                                 Id=user.Id,
                                 claim=operationClaim.Name                
                            
                             };
                return result.ToList();
            }
        }




    }
}
