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
    public class CarManager : ICarService
    {
        IProductDal _productDal;
        public CarManager(IProductDal product)
        {
            _productDal = product;
        }

        public List<Car> GetAll()
        {
           return _productDal.GetAll();
        }
    }
}
