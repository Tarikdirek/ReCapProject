using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ProjectDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ProjectDbContext context = new ProjectDbContext())
            {
                var result = from d in context.Cars
                             join b in context.Brands
                             on d.CarId equals b.BrandId
                             join c in context.Colors
                             on d.ColorId equals c.ColorId

                             select new CarDetailDto { Descriptoin = d.Description, BrandName = b.BrandName,ColorName=c.ColorName };
                return result.ToList();
            }
        }
    }
}
