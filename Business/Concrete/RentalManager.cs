using Business.Abstract;
using Business.BusinessAsbect;
using Business.Constans;
using Core.Asbect.Autofac.Caching;
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
        [SecuredOperation("admin")]
       // [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {         
                         
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.CarAdded);

            
        }
        public IDataResult<List<Rental>> GetCarControl(int carId, DateTime rentDateControl, DateTime returnDateControl)

        {       var rentDate = Convert.ToInt32(rentDateControl.ToOADate()); 
                var returnDate = Convert.ToInt32(returnDateControl.ToOADate());

            if (rentDate<returnDate)
            {  
                var resultData = _rentalDal.GetAll(c => c.CarId == carId);
               
               foreach (var item in resultData)
                {
                    var requestRentDate = Convert.ToInt32(item.RentDate.ToOADate());
                    var requestReturnDate = Convert.ToInt32(item.ReturnDate.ToOADate());

                    for (int i = rentDate; i <= returnDate; i++)
                    {
                        for (int a = requestRentDate; a < requestReturnDate; a++)
                        { 
                            if (a==i )
                        {
                          return new  ErrorDataResult<List<Rental>>("Araç Uygun Değil");
                        }

                        }
                       

                       
                    }                    
                }
               
            }
                return new SuccessDataResult<List<Rental>>("Araç Uygun");


//var result = _rentalDal.getdatecontrol(c => c.CarId == rental.CarId && Convert.ToInt32(c.RentDate.ToOADate()) <= rentDate
//                    && Convert.ToInt32(c.ReturnDate.ToOADate()) >= returnDate);
//            return new SuccessDataResult<List<Rental>>(result, Messages.Listed);
//            return new ErrorDataResult<List<Rental>>(Messages.ErrorMessage); ;
            
           
        }

        // [SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<Rental> GetByCarId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.CarId == id), Messages.Listed);
        }
        [CacheAspect]
        public IDataResult<List<RentalDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.GetRentalDetails());
        }
       // [SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
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
                return new ErrorDataResult<List<Rental>>("Araç Durumu Müsait değil");
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(result,"Araç Müsait");

            }
        
        }
    }
}

