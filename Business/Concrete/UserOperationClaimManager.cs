using Business.Abstract;
using Business.Constans;
using Core.Entities.Entity;
using Core.Utilities;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationDal)
        {
            _userOperationClaimDal = userOperationDal;
        }
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.useroperationclaimAdded);
        }

        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.useroperationclaimDelete);
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }
        public IDataResult<UserOperationClaim> GetClaimByUserId(int userId)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(p => p.UserId == userId));
        }
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            var claim = GetClaimByUserId(userOperationClaim.UserId).Data;
            claim.UserId = userOperationClaim.UserId;
            claim.OperationClaimsId = userOperationClaim.OperationClaimsId;
            claim.Id = userOperationClaim.Id;

            _userOperationClaimDal.Update(claim);
            return new SuccessResult(Messages.useroperationclaimUpdate);
        }
    }
}
