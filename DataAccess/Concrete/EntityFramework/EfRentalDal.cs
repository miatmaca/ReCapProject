using Core.DataAcces.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from rent in context.Rentals

                             join cars in context.Cars
                             on rent.CarId equals cars.CarId

                             join brand in context.Brands
                             on cars.BrandId equals brand.BrandId

                             join customer in context.Customers
                             on rent.CustomerId equals customer.UserId

                             join users in context.Users
                             on customer.UserId equals users.Id

                             select new RentalDto
                             {
                                 CarName = brand.BrandName,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Id = rent.Id,
                                 RentDate = rent.RentDate,
                                 ReturnDate = rent.ReturnDate

                             };


                return result.ToList();
            }

        }
        public List<Rental> getdatecontrol(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return filter == null
                    ? context.Set<Rental>().ToList()
                    : context.Set<Rental>().Where(filter).ToList();
            }
        }

        //public List<Rental> getdate(Rental rental)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        var result = from x in context.Rentals
        //                     where x.RentDate >= rental.RentDate &&
        //                     x.ReturnDate <= rental.ReturnDate ;




        //               } }

    }
}
