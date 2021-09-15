using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDto>> GetRentalDetails();
        IDataResult<Rental> GetByCarId(int id);
        IDataResult<List<Rental>> getDate(DateTime date, int carId);
    }
}
