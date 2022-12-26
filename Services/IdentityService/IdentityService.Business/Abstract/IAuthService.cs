using CorePackage.Entities.Concrete;
using CorePackage.Helpers.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IdentityService.Entities.DTO.UserDTO;

namespace IdentityService.Business.Abstract
{
    public interface IAuthService
    {
        IResult Login(LoginDTO login);
        IResult Register(RegisterDTO register);
        IDataResult<User> GetUserByEmail(string email);
    }
}