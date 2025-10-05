using Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;
using PRN232.Lab2.CoffeeStore.Services.Interfaces;

namespace PRN232.Lab2.CoffeeStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBaseWithBaseReponse
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<BaseActionResult<TokenResponse>> Login([FromBody]Login login)
        {
            var result = await _authService.LoginAsync(login);
            return result.Match(
                token => Ok(token),
                error => BadRequest(error)
            );
        }

        [HttpPost("register")]
        public async Task<BaseActionResult<string>> Register([FromBody] RegisterRequest register)
        {
            var result = await _authService.RegisterAsync(register, "USER");
            return result.Match(
                message => Ok(message),
                error => BadRequest(error)
            );
        }

        [HttpPost("refresh-token")]
        public async Task<BaseActionResult<TokenResponse>> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var result = await _authService.RefreshTokenAsync(request);
            return result.Match(
                token => Ok(token),
                error => BadRequest(error)
            );
        }

    }
}
