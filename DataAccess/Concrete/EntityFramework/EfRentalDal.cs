using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ProjectDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>>? filter = null)
        {
            using (ProjectDbContext contex = new ProjectDbContext())
            {
                var result = from c in contex.Cars
                    join b in contex.Brands on c.CarId equals b.BrandId
                    join r in contex.Rentals on c.CarId equals r.CarId
                    join co in contex.Colors on c.ColorId equals co.ColorId
                    join cu in contex.Customers on r.CustomerId equals cu.CustomerId
                    join u in contex.Users on cu.UserId equals u.Id

                    select new RentalDetailDto
                    {
                        BrandName = b.BrandName, FirstName = u.FirstName, LastName = u.LastName, Id = c.CarId,
                        RentDate = r.RentDate, ReturnDate = (DateTime)r.ReturnDate , ColorName = co.ColorName,Description = c.Description, 
                        ModelYear=c.ModelYear.ToString()
                    };

                if (filter == null)
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
