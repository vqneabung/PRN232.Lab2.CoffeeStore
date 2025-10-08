using Common;
using Common.DTOs.Request;
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
    public class OrdersController : ControllerBaseWithBaseReponse
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;

        public OrdersController(IOrderService orderService, UserManager<User> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [Authorize (Roles = "Admin")]
        [HttpGet("user/{userId}")]
        public async Task<BaseActionResult<IEnumerable<OrderResponse>>> GetOrdersByUserId(Guid userId, [FromBody] SearchPagedSortedRequest request)
        {

            var orders = await _orderService.GetAllOrdersByUserIdAsync(userId, request);
            return Ok(orders);
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet("user/current")]
        public async Task<BaseActionResult<IEnumerable<OrderResponse>>> GetOrdersByCurrentUser([FromBody] SearchPagedSortedRequest request)
        {
            var userEmail = User.Identity?.Name;
            if (string.IsNullOrEmpty(userEmail))
            {
                return Unauthorized(new BaseError { Message = "User is not authenticated." });
            }
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return NotFound(new BaseError { Message = "User not found." });
            }
            var orders = await _orderService.GetAllOrdersByUserIdAsync(user.Id, request);
            return Ok(orders);
        }

        [Authorize (Roles = "Admin")]
        [HttpGet]
        public async Task<BaseActionResult<IEnumerable<OrderResponse>>> GetAllOrders(SearchPagedSortedRequest request)
        {
            var orders = await _orderService.GetPagedAsync(request);
            return Ok(orders);
        }

        [Authorize(Roles = "User")]
        [HttpGet("detail/{orderId}")]
        public async Task<BaseActionResult<IEnumerable<OrderDetailResponse>>> GetOrderDetailById(Guid orderId)
        {
            var orderDetails = await _orderService.GetOrderDetailByOrderIdAsync(orderId);
            return Ok(orderDetails);
        }

        [Authorize (Roles = "Admin,User")]
        [HttpGet("{id}")]
        public async Task<BaseActionResult<OrderResponse>> GetById(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            return Ok(order);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<BaseActionResult<bool>> Create([FromBody] CreateOrderRequest request)
        {
            var result = await _orderService.CreateAsync(request);
            return result.Match(
                success => Ok(success),
                error => BadRequest(error)
            );
        }

        [Authorize (Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<BaseActionResult<bool>> Delete(Guid id)
        {
            var result = await _orderService.DeleteAsync(id);
            return result.Match(
                success => Ok(success),
                error => BadRequest(error)
            );
        }

    }
}
