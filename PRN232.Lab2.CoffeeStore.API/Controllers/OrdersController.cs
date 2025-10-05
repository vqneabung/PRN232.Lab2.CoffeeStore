using Common;
using Common.DTOs.Request;
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
    public class OrdersController : ControllerBaseWithBaseReponse
    {
        private readonly IOrderService _orderService;   
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("user/{userId}")]
        public async Task<BaseActionResult<IEnumerable<OrderResponse>>> GetOrdersByUserId(Guid userId)
        {
            var orders = await _orderService.GetAllOrdersByUserIdAsync(userId);
            return Ok(orders);
        }

        [HttpGet]
        public async Task<BaseActionResult<IEnumerable<OrderResponse>>> GetAllOrders(PagedAndSortedRequest request)
        {
            var orders = await _orderService.GetAllAsync(request);
            return Ok(orders);
        }

        [HttpGet("detail/{orderId}")]
        public async Task<BaseActionResult<IEnumerable<OrderDetailResponse>>> GetOrderDetailById(Guid orderId)
        {
            var orderDetails = await _orderService.GetOrderDetailByOrderIdAsync(orderId);
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<BaseActionResult<OrderResponse>> GetById(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<BaseActionResult<bool>> Create([FromBody] CreateOrderRequest request)
        {
            var result = await _orderService.CreateAsync(request);
            return result.Match(
                success => Ok(success),
                error => BadRequest(error)
            );
        }

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
