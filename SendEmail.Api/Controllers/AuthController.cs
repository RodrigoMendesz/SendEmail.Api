
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SendEmail.Api.Business.Services;
using SendEmail.Api.Business.Services.Interfaces;
using SendEmail.Api.Data.DTOs;
using SendEmail.Api.Data.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SendEmail.Api.Controllers
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
        public IActionResult Login([FromBody] UserModel user)
        {   
            var authenticatedUser = _authService.Authenticate(user.Username, user.PasswordHash);
            if (authenticatedUser == null)
            {
                return Unauthorized();
            }

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }


       
    }
}
