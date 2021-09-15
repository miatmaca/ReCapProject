using Core.DataAcces.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;



namespace DataAccess.Concrete.EntityFramework
{
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, ReCapContext>, IPaymentDal
    {
        //public List<RentalDto> GetPaymentDetails(Expression<Func<RentalDto, bool>> filter = null)
        //{
        //    using (ReCapContext context= new ReCapContext())
        //    {
        //        var result = from c in context.CreditCards
        //                     join p in context.Payments
        //                     on c.CreditCartId equals p.PaymentId

        //                     join user in context.Users
        //                     on p.CustomerId equals user.Id
        //                     select new PaymentDto
        //                     {
        //                         CreditCartId = c.CreditCartId,
        //                         CustomerId = p.CustomerId,
        //                         CardNumber = c.CardNumber,
        //                         CardLimit = c.CardLimit,
        //                         CardType = c.CardType,
        //                         ExpMounth = c.ExpMounth,
        //                         ExpYear = c.ExpYear,
        //                         Amount = p.Amaunt,
        //                         CVV = c.CVV,
        //                         FullName = user.FirstName



        //                     };
        //        return filter == null ? result.ToList() : result.Where(filter).ToList();
        //    }
        //}
        public List<RentalDto> GetPaymentDetails(Expression<Func<RentalDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
