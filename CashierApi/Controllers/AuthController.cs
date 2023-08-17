using BusinessLayer.Abstract;
using EntityLayer.Concrete.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashierApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var userToLogin = await _authService.Login(loginDto);
            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.MyMessage);
            }
            var result = await _authService.CreateAccessToken(userToLogin.Data);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.MyMessage);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var userExist = await _authService.USerExist(registerDto.Email);
            if (!userExist.IsSuccess)
            {
                return BadRequest(userExist.MyMessage);
            }
            var registerResult = await _authService.Register(registerDto);
            var result = await _authService.CreateAccessToken(registerResult.Data);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.MyMessage);
        }
    }
}