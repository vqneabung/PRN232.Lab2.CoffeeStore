using Common.DTOs.Request;
using Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;
using PRN232.Lab2.CoffeeStore.Services.Interfaces;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.API.Controllers
{
    [Authorize (Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBaseWithBaseReponse
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<BaseActionResult<UserResponse>> GetAlls()
        {
            var result = await _userService.GetAlls();

            return result.Match(
                users => Ok(users),
                error => BadRequest(error)
            );
        }
        
        [HttpGet("{id}")]
        public async Task<BaseActionResult<UserResponse>> GetById(Guid id)
        {
            var result = await _userService.GetById(id);
            return result.Match(
                user => Ok(user),
                error => BadRequest(error)
            );
        }

        [HttpDelete("{id}")]
        public async Task<BaseActionResult<bool>> Delete(Guid id)
        {
            var result = await _userService.Delete(id);
            return result.Match(
                success => Ok(success),
                error => BadRequest(error)
            );
        }
    }
}
