using IdentityAndDataProtection.Dtos;
using IdentityAndDataProtection.Models;
using IdentityAndDataProtection.Services;
using IdentityDataProtectionJWT.Dtos;
using IdentityDataProtectionJWT.Jwt;
using IdentityDataProtectionJWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAndDataProtection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addUserDto = new AddUserDto
            {
                Email = request.Email,
                Password = request.Password,
            };

            var result = await _userService.AddUser(addUserDto);
            if (result.IsSucceed)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("login")]
        
        public async Task<IActionResult> Login(LoginRequest login)
        {
            var loginUserDto = new LoginUserDto
            {
                Email = login.Email,
                Password = login.Password,
            };

            var result = await _userService.LoginUser(loginUserDto);
            if (result.IsSucceed)
                return BadRequest(result.Message);

            var user = result.Data;

            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            // appsettings kısmındaki servisleri çağırabiliriz

            var token = JwtHelper.GenerateJwtToken(new JwtDto
            {
                Id = user.Id,
                Email = user.Email,
                UserType = user.UserType,
                // appsettingsjson issuer,audience gibi veriler builder.configuration ile çağrılıyor
                // ama burada kullanamıyoruz property injection ile alıyoruz configuration tanımlıyoruz
                SecretKey = configuration["Jwt:SecretKey"]!,
                Issuer = configuration["Jwt:Issuer"]!,
                Audience = configuration["Jwt:Audience"]!,
                ExpireMinutes = int.Parse(configuration["Jwt:ExpireMinutes"]!)
            
            
            
            });

            return Ok(new LoginResponse
            {
                Message = "Login completed welcome to us.",
                Token = token
            });

        }

        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public IActionResult User()
        {
            return Ok();
        }



    }
}
