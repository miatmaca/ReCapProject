using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IPaymentService
    {
        IDataResult<List<Payment>> GetPaymentId(int paymentId);
        IResult Add(Payment payment);
        IResult Update(Payment payment);
        IResult Delete(Payment payment);
        IDataResult<List<Payment>> GetAll();
        IDataResult<List<Payment>> GetPaymentDetails(int creditCardId);//dto olacak

    }
}
