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
using Core.Utilities.Business;

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

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(int id)
        {
            
            return new SuccessDataResult<List<RentalDetailDto>>(_rental.GetRentalDetails(r => r.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rental.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult IsCarAvailable(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarAvailableForRent(carId));
            if (result!= null)
            {
                return new ErrorResult("Car is not available for rent");
            }
            return new SuccessResult("Car is available for rent");
        }

        public IResult CheckIfCarAvailableForRent(int rentalId)
        {
            var result = _rental.GetRentalDetails(r => r.Id == rentalId).Any();
            if (result == true)
            {
                return new ErrorResult();
            }
            return new SuccessResult();            
        }
    }
}
