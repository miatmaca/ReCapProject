using Business.Abstract;
using Business.BusinessAsbect;
using Business.Constans;
using Core.Asbect.Autofac.Caching;
using Core.Entities.Entity;
using Core.Utilities;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal user)
        {
            _userDal = user;
        }
        //[CacheRemoveAspect("IUserService.Get")]
       // [SecuredOperation("admin")]        
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }
       // [CacheRemoveAspect("IUserService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }
          public IDataResult<List<User>> GetEmailById(string email)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(p=>p.Email==email));


        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }
        [CacheAspect]
        public User GetByMail(string mail)
        {
            return _userDal.Get(c => c.Email == mail);
        }
        [CacheAspect]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        [CacheAspect]
        public IDataResult<List<User>> GetUserId(int id)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u=>u.Id==id));
        }
      //  [CacheRemoveAspect("IUserService.Get")]
      //  [SecuredOperation("admin")]
        public IResult Update(UserForRegisterDto user)
        {
            
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
            var result = new User
            {   Id=user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userDal.Update(result);
            return new SuccessResult(Messages.Update);
        }
    }
}
