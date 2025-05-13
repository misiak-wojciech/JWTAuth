using JWTAuth.DTOs;
using JWTAuth.Entities;
using JWTAuth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        public static User user = new();

        [HttpPost("register")]

        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await authService.RegisterAsync(request);
            if (user == null)
            {
                return BadRequest("User already exists");
            }
                return Ok(user);
        }

        [HttpPost("login")]

        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {
            var result= await authService.LoginAsync(request);
            if (result == null)
            {
                return BadRequest("Invalid username or password");
            }

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("You are authenicated");

        }

        [Authorize(Roles ="Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("You are an admin");

        }

        [HttpPost("refresh-token")]

        public async Task<ActionResult<TokenResponseDto>> RefreshToken (RefreshTokenRequestDto request )
        {
            var result = await authService.RefreshTokensAsync(request);

            if(result is null || result.AccesToken is null || result.RefreshToken is null)
                return Unauthorized("Invalid refresh token");

            return Ok(result);
        }




    }


}
