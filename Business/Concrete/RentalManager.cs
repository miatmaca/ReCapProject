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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            //if (rental.ReturnDate != null)
            //{
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            //}
            //else
            //{
            //    return new ErrorResult(Messages.ErrorMessage);
            //}
        }         

            
            
        }
    }

