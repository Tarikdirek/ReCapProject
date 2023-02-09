using Business.Abstract;
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

        public void Add(Brand brand)
        {
            _brand.Add(brand);
            Console.WriteLine(brand.BrandName + " added on database.");
        }

        public void Delete(Brand brand)
        {
            _brand.Delete(brand);
            Console.WriteLine(brand.BrandName + " deleted from database.");
            
        }

        public List<Brand> GetAll()
        {
            return _brand.GetAll();
        }

        public Brand GetById(int brandtId)
        {
            return _brand.Get(b=> b.BrandId == brandtId);
        }

        public void Update(Brand brand)
        {
           _brand.Update(brand);
            Console.WriteLine(brand.BrandName + " updated.");
        }
    }
}
