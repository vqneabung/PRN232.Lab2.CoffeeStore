using Common;
using Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;
using PRN232.Lab2.CoffeeStore.Repositories.Entities;
using PRN232.Lab2.CoffeeStore.Services.Interfaces;

namespace PRN232.Lab2.CoffeeStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBaseWithBaseReponse
    {
        private readonly IAuthService _authService;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, UserManager<User> userManager, IUserService userService)
        {
            _authService = authService;
            _userManager = userManager;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<BaseActionResult<TokenResponse>> Login([FromBody]Login login)
        {
            var result = await _authService.LoginAsync(login);
            return result.Match(
                token => Ok(token),
                error => Unauthorized(error)
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

        [Authorize]
        [HttpGet("current")]
        public async Task<BaseActionResult<UserResponse>> GetCurrentUser()
        {
            var userId = User.Identities.FirstOrDefault()?.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new BaseError { Message = "User is not authenticated." });
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound(new BaseError { Message = "User not found." });
            }
            var result = await _userService.GetById(user.Id);
            return result.Match(
                userResponse => Ok(userResponse),
                error => BadRequest(error)
            );
        }
    }
}
