using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal car)
        {
            _carDal = car;
        }

        public IResult Add(Car car)
        {

            if (car.DailyPrice > 0 && car.Description.Length > 2)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);

            }
            else
            {
                return  new ErrorResult(Messages.CarNameInvalid + " or " + Messages.CarPriceInvalid);

            }


        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted); 
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour > 17)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);

            }
            
        }

        public IDataResult<Car> GetById(int CarId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == CarId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsDailyPrice(int min)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice > min));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
