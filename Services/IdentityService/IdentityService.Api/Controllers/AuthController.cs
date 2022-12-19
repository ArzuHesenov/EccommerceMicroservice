using IdentityService.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static IdentityService.Entities.DTO.UserDTO;

namespace IdentityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDTO login)
        {
            var result = _authService.Login(login);
            if(result.Success)
            {
                return Ok(new { status = 200, message = result.Message });
            }
            return BadRequest(result.Message);
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDTO register)
        {
            var result = _authService.Register(register);
            if(result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
