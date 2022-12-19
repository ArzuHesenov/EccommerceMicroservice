using CorePackage.DataAccess.EntityFramework;
using CorePackage.Entities.Concrete;
using IdentityService.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.DataAccess.Concrete.EntityFramework
{
    public class UserDal : EfRepositoryBase<User, IdentityDbContext>, IUserDal
    {
    }
}
