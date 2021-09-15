using Business.Abstract;
using Business.Constans;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentService;

        public PaymentManager(IPaymentDal paymentService)
        {
            _paymentService = paymentService;
        }

        public IResult Add(Payment payment)
        {


            _paymentService.Add(payment);
            return new SuccessResult(Messages.PaymentAdded);
        }

        public IResult Delete(Payment payment)
        {
            _paymentService.Delete(payment);
            return new SuccessResult(Messages.PaymentDelete);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentService.GetAll());
        }

        public IDataResult<List<Payment>> GetPaymentDetails(int creditCardId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Payment>> GetPaymentId(int paymentId)
        {
            return new SuccessDataResult<List<Payment>>(_paymentService.GetAll(p => p.PaymentId == paymentId));
        }

        public IResult Update(Payment payment)
        {
            _paymentService.Delete(payment);
            return new SuccessResult(Messages.PaymentUpdate);
        }

    }   
}
