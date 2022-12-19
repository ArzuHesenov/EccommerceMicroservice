using CorePackage.DataAccess;
using CorePackage.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.DataAccess.Abstract
{
    public interface IUserDal : IRepositoryBase<User>
    {
    }
}
