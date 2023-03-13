using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ProjectDbContext>,IUserDal
    {
        public List<OperationClaim> GetClaims (User user) 
        {
            using (var contex = new ProjectDbContext())
            {
                var result = from operationClaims in contex.OperationClaims
                             join userOperationClaims in contex.userOperationClaims
                             on operationClaims.Id equals userOperationClaims.Id
                             where userOperationClaims.UserId == user.Id
                             select new OperationClaim {Id = operationClaims.Id,Name = operationClaims.Name };
                return result.ToList();
            }
        
        }
    }
}
