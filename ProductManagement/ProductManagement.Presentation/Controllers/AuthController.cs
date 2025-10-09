using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ProductManagement.Application.Dtos.Request;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Dtos.Response;

namespace ProductManagement.Presentation.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto) 
        {
            var user = await _userService.AuthenticateAsync(loginRequestDto.Email, loginRequestDto.Password);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
                new Claim(ClaimTypes.Name, user.Username),               
                new Claim(ClaimTypes.Role, user.Role)                    
            };
            var tokenString = _tokenService.CreateToken(claims);
            return Ok(new LoginResponseDto { Token = tokenString });
        }

        [HttpPost("Register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            try
            {
                var newUser = await _userService.RegisterAsync(registerRequestDto);
                return Ok(newUser);
            }
            catch (System.ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
