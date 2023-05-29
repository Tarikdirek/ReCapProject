using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rental;

        public RentalManager(IRentalDal rental)
        {
            _rental = rental;
        }

        public IResult Add(Rental rental)
        {
            if (!(rental.ReturnDate == null))
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }
            else
            {
                _rental.Add(rental);
                return new SuccessResult(Messages.RentalAdded);

            }

        }

        public IResult Delete(Rental rental)
        {
            _rental.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rental.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rental.Get(r => r.Id == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rental.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rental.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
