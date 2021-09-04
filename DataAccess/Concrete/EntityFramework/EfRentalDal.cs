using Core.DataAcces.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from rent in context.Rentals

                             join user in context.Users
                             on rent.CustomerId equals user.Id

                             join car in context.Cars
                             on rent.CarId equals car.BrandId
                             
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                                                         
                             select new RentalDto
                             {
                                 CarName = brand.BrandName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Id = rent.Id,
                                 RentDate = rent.RentDate,
                                 ReturnDate = rent.ReturnDate
                                 
                             }; 

                
                return result.ToList();
            }


        }
    }
}
