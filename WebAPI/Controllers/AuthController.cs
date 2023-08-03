using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExist = _authService.UserExist(userForRegisterDto.Email);

            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);

            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("passwordupdate")]
        public IActionResult PasswordUpdate(UserForPasswordUpdateDto userForPasswordUpdateDto)
        {
            var result = _authService.UpdateUserPassword(userForPasswordUpdateDto, userForPasswordUpdateDto.NewPassword);
            if (result.Success) { return Ok(result); } return BadRequest(result.Message);
        }
    }
}
