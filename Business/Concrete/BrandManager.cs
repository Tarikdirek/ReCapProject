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

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brand;

        public BrandManager(IBrandDal brand)
        {
            _brand = brand;
        }

        public IResult Add(Brand brand)
        {
            _brand.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brand.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
            
            
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brand.GetAll(),Messages.BrandsListed);
            
        }

        public IDataResult<Brand> GetById(int brandtId)
        {
            
            return new SuccessDataResult<Brand>(_brand.Get(b=> b.BrandId == brandtId));
        }

        public IResult Update(Brand brand)
        {
           _brand.Update(brand);
           return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
