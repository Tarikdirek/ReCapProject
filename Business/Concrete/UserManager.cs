﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _user;

        public UserManager(IUserDal user)
        {
            _user = user;
        }

        public IResult Add(User user)
        {
            _user.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _user.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_user.GetAll());
        }

        public User GetByEmail(string email)
        {
            var result = _user.Get(u => u.Email == email);
            return result ;
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_user.Get(u => u.Id == userId));
        }

        public List<OperationClaim> GetClaims(User user)
        {
            var result = _user.GetClaims(user);
            return result;
        }

        //public User GetUser(string email, string updatedEmail)
        //{
        //    var result = _user.Get(u => u.Email == email);
        //    result.Email = updatedEmail;
           
        //    _user.Update(result);
            
        //    return  new User { Email=result.Email,FirstName=result.FirstName,LastName=result.LastName,PasswordHash=result.PasswordHash
        //    ,PasswordSalt=result.PasswordSalt,Status=result.Status};

        //}

        public IResult Update(User user)
        {
            _user.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult UpdateUserNames(UserForUpdateDto user)
        {
            var updatedUser = _user.Get(u => u.Id == user.Id);
            updatedUser.FirstName = user.FirstName;
            updatedUser.LastName = user.LastName;
            _user.Update(updatedUser);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
