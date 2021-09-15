using Business.Abstract;
using Business.Constans;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditcardService;

        public CreditCardManager(ICreditCardDal creditcardService)
        {
            _creditcardService = creditcardService;
        }

        public IResult Add(CreditCard creditcard)
        {
            _creditcardService.Add(creditcard);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        public IDataResult<List<CreditCard>> CreditControl(int amount ,string cardNumber,int ExpMonth,int ExpYear,int CVV,string CardType,string fullname)
        {
            var result = new SuccessDataResult<List<CreditCard>>(_creditcardService.GetAll(
           p =>  p.CardNumber==cardNumber&&p.CardType==CardType &&p.CVV==CVV &&p.ExpMonth==ExpMonth&&p.ExpYear==ExpYear&&p.FullName==fullname));
            return CartControl(amount, result);
        }

       

        public IResult Delete(CreditCard creditcard)
        {
            _creditcardService.Delete(creditcard);
            return new SuccessResult(Messages.CreditCardDelete);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditcardService.GetAll());
        }

        public IDataResult<List<CreditCard>> GetPaymentId(int creditcardId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditcardService.GetAll(p => p.CreditCartId == creditcardId));
        }

        public IResult Update(CreditCard creditcard)
        {
            _creditcardService.Update(creditcard);
            return new SuccessResult(Messages.CreditCardUpdate);
        }


        private IDataResult<List<CreditCard>> CartControl(int amount, SuccessDataResult<List<CreditCard>> result)
        {
            if (result.Data.Count<=0)
            {
                return new ErrorDataResult<List<CreditCard>>(Messages.NoEmptyCreditCard);
            }
            else

            {
                foreach (var item in result.Data)
                {
                    if (item.CardLimit < amount)
                    {
                        return new ErrorDataResult<List<CreditCard>>(Messages.InsBalance);
                    }
                    else
                    {
                        item.CardLimit = item.CardLimit - amount;
                        _creditcardService.Update(item);
                        return new SuccessDataResult<List<CreditCard>>(result.Data, Messages.Succes);
                    }

                }
                //Kontrol Et
            }
            return result;
        }

    }
}
