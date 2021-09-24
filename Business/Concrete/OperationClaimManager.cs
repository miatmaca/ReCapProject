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
    public class OperationClaimManager : IOperationClaimService
    {
        IOperationClaimDal _operationClaimService;
        public OperationClaimManager(IOperationClaimDal operationService)
        {
            _operationClaimService = operationService;
        }
        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimService.Add(operationClaim);
            return new SuccessResult(Messages.useroperationclaimAdded);
        }

        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimService.Delete(operationClaim);
            return new SuccessResult(Messages.useroperationclaimDelete);
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimService.GetAll());
        }
             

        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimService.Update(operationClaim);
            return new SuccessResult(Messages.useroperationclaimUpdate);
        }
    }
}
