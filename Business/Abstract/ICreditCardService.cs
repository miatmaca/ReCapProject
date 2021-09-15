using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetPaymentId(int creditcardId);
        IResult Add(CreditCard creditcard);
        IResult Update(CreditCard creditcard);
        IResult Delete(CreditCard creditcard);
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<List<CreditCard>> CreditControl( int amount, string cardNumber, int ExpMonth, int ExpYear, int CVV, string CardType, string fullname);

    }
}
