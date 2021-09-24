﻿using Core.DataAcces.EntityFrameWork;
using Core.Entities.Entity;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
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
    }
}
