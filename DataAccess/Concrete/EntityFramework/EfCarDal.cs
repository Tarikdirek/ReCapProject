using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ProjectDbContext>, ICarDal
    {
        //public CarDetailDto GetCarDetailByBrandId(Expression<Func<CarDetailDto, bool>> filter)
        //{
        //    using (ProjectDbContext context = new ProjectDbContext())
        //    {
        //        var result = from d in context.Cars
        //                     join b in context.Brands
        //                     on d.CarId equals b.BrandId
        //                     join c in context.Colors
        //                     on d.ColorId equals c.ColorId
        //                     join i in context.CarImages
        //                     on d.CarId equals i.CarId

        //                     select new CarDetailDto
        //                     {
        //                         CarId = d.CarId,
        //                         Descriptoin = d.Description,
        //                         BrandName = b.BrandName,
        //                         ColorName = c.ColorName,
        //                         ModelYear = d.ModelYear,
        //                         DailyPrice = d.DailyPrice,
        //                         BrandId = b.BrandId,
        //                         ColorId = c.ColorId,
        //                         ImagePath = i.ImagePath
        //                     };
        //        return result.(filter);
        //    }
        //}

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>>? filter = null)
        {
            using (ProjectDbContext context = new ProjectDbContext())
            {
                var result = from d in context.Cars
                             join b in context.Brands
                             on d.CarId equals b.BrandId
                             join c in context.Colors
                             on d.ColorId equals c.ColorId
                             join i in context.CarImages
                             on d.CarId equals i.CarId

                             select new CarDetailDto {CarId = d.CarId,Description = d.Description, BrandName = b.BrandName,
                                 ColorName=c.ColorName,ModelYear =d.ModelYear,DailyPrice = d.DailyPrice,BrandId=b.BrandId,
                                 ColorId=c.ColorId,ImagePath=i.ImagePath};
                

                if (filter==null)
                {
                    return result.ToList();
                }
                else
                {
                    return result.Where(filter).ToList();
                }
            }
        }
    }
}

//return filter == null
//                   ? context.Set<TEntity>().ToList()
//               : context.Set<TEntity>().Where(filter).ToList();
