using Core.Entities.Entity;
using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService
    {
        IDataResult<List<User>> GetUserId(int id);
        IResult Add(User user);
        IResult Update(UserForRegisterDto user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string mail);
        IDataResult<List<User>> GetEmailById(string email);
    }
}
