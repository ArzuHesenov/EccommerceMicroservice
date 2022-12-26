using AutoMapper;
using CorePackage.Entities.Concrete;
using CorePackage.Helpers.Result.Abstract;
using CorePackage.Helpers.Result.Concrete.ErrorResults;
using CorePackage.Helpers.Result.Concrete.SuccessResults;
using CorePackage.Security.Hashing;
using CorePackage.Security.Jwt;
using IdentityService.Business.Abstract;
using IdentityService.Business.Constants;
using IdentityService.DataAccess.Abstract;
using IdentityService.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IdentityService.Entities.DTO.UserDTO;

namespace IdentityService.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public AuthManager(IUserService userService, IUserDal userDal, IMapper mapper)
        {
            _userService = userService;
            _userDal = userDal;
            _mapper = mapper;
        }

        public IDataResult<User> GetUserByEmail(string email)
        {
            try
            {
                var result = _userDal.Get(x => x.Email == email);
                return new SuccessDataResult<User>(result);
            }
            catch (Exception)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
        }

        public IResult Login(LoginDTO login)
        {
            try
            {
                var findUserByEmail = GetUserByEmail(login.Email);
                if (!findUserByEmail.Success)
                {
                    return new ErrorResult(Messages.LoginError);
                }
                var checkPassword = HashingHelper.VerifyPassword(login.Password, findUserByEmail.Data.PasswordHash, findUserByEmail.Data.PasswordSalt);
                if(!checkPassword)
                {
                    return new ErrorResult(Messages.LoginError);
                }
                string token = TokenGenerator.Token(findUserByEmail.Data, "User");
                return new SuccessResult(token);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public IResult Register(RegisterDTO register)
        {
            try
            {
                var findUserByEmail = _userService.GetUserByEmail(register.Email);
                if (findUserByEmail.Success)
                    return new ErrorResult(Messages.UserExists);
                byte[] passwordHash, passwordSalt;
                var model = _mapper.Map<User>(register);
                HashingHelper.HashPassword(register.Password, out passwordHash, out passwordSalt);
                model.PasswordHash = passwordHash;
                model.PasswordSalt = passwordSalt;
                model.ProfilePicture = "/";
                _userDal.Add(model);
                return new SuccessResult(Messages.RegisterSuccessfully);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
