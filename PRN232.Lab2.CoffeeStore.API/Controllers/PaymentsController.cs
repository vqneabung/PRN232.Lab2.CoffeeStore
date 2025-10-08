    using Common.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using PRN232.Lab2.CoffeeStore.Services.Interfaces;
    using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request;
    using Common.DTOs.Request;

    namespace PRN232.Lab2.CoffeeStore.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class PaymentsController : ControllerBaseWithBaseReponse
        {
            private readonly IPaymentService _paymentService;

            public PaymentsController(IPaymentService paymentService)
            {
                _paymentService = paymentService;
            }

            [HttpGet]
            public async Task<IActionResult> GetPagedAsync([FromQuery] SearchPagedSortedRequest request)
            {
                var result = await _paymentService.GetPagedAsync(request);
                return result.Match<IActionResult>(
                    pagedResponse => Ok(pagedResponse, "Get all payments successfully"),
                    error => BadRequest(error.Message)
                );
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(Guid id)
            {
                var result = await _paymentService.GetByIdAsync(id);
                return result.Match<IActionResult>(
                    paymentResponse => Ok(paymentResponse, "Get payment successfully"),
                    error => NotFound(error.Message)
                );
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreatePaymentRequest request)
            {
                var result = await _paymentService.CreateAsync(request);
                return result.Match<IActionResult>(
                    success => Ok("Payment created successfully"),
                    error => BadRequest(error.Message)
                );
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(Guid id)
            {
                var result = await _paymentService.DeleteAsync(id);
                return result.Match<IActionResult>(
                    success => Ok("Payment deleted successfully"),
                    error => NotFound(error.Message)
                );
            }
        }
    }
