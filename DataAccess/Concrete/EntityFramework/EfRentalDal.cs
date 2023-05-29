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

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ProjectDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ProjectDbContext contex = new ProjectDbContext())
            {
                var result = from c in contex.Cars
                    join b in contex.Brands on c.CarId equals b.BrandId
                    join r in contex.Rentals on c.CarId equals r.CarId
                    join co in contex.Customers on r.CustomerId equals co.CustomerId
                    join u in contex.Users on co.UserId equals u.Id

                    select new RentalDetailDto
                    {
                        BrandName = b.BrandName, FirstName = u.FirstName, LastName = u.LastName, Id = r.Id,
                        RentDate = r.RentDate, ReturnDate = (DateTime)r.ReturnDate
                    };

                return result.ToList();

            }
        }
    }
}
