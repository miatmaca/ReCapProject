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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            Rental result = this.GetByCarId(rental.CarId).Data;
            if (result != null && result.ReturnDate != null)
            {
                return new ErrorResult(Messages.CarRented);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.CarAdded);

            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetByCarId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.CarId == id), Messages.Listed);
        }

        public IDataResult<List<RentalDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Update);
        }
        public IDataResult<List<Rental>> getDate(DateTime date ,int carId)
        {
           var result = _rentalDal.GetAll(c => c.RentDate == date && c.CarId == carId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(c => c.RentDate == date && c.CarId == carId), Messages.Listed);
            }
            else
            {
                return new ErrorDataResult<List<Rental>>(Messages.ErrorMessage);

            }
        
        }
    }
}

