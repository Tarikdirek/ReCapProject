﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars= new List<Car> {
            
                new Car{CarId=1, BrandId=1,ColorId=1,Description="BMV 5.25", DailyPrice=2000000,ModelYear=2018 },
                new Car{CarId=2, BrandId=2,ColorId=2,Description="Porshe GT", DailyPrice=3000000,ModelYear=2020 },
                new Car{CarId=3, BrandId=3,ColorId=3,Description="Wolksvagen Passat", DailyPrice=1000000,ModelYear=2020 },
                new Car{CarId=4, BrandId=4,ColorId=1,Description="Skoda Fabia", DailyPrice=1500000,ModelYear=2021 },
                new Car{CarId=5, BrandId=5,ColorId=2,Description="Audi R8", DailyPrice=2500000,ModelYear=2022 }

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrandId(int BrandId)
        {
            return _cars.Where(c=>c.BrandId==BrandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetCarDetailByBrandId(Expression<Func<CarDetailDto, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
