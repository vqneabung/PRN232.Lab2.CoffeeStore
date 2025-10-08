using Common.DTOs.Request;
using Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;
using PRN232.Lab2.CoffeeStore.Services.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace PRN232.Lab2.CoffeeStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBaseWithBaseReponse
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<BaseActionResult<IEnumerable<ProductResponse>>> GetPagedAsync(SearchPagedSortedRequest request)
        {
            var result = await _productService.GetPagedAsync(request);
            return result.Match(
                products => Ok(products),
                error => BadRequest(error)
            );
        }

        [HttpGet("{id}")]
        public async Task<BaseActionResult<ProductResponse>> GetById(Guid id)
        {
            var result = await _productService.GetById(id);
            return result.Match(
                product => Ok(product),
                error => BadRequest(error)
            );
        }

        [Authorize (Roles = "Admin")]
        [HttpPost]
        public async Task<BaseActionResult<bool>> Create([FromBody] CreateProductRequest request)
        {
            var result = await _productService.Create(request);
            return result.Match(
                success => Ok(success),
                error => BadRequest(error)
            );
        }

        [Authorize (Roles = "Admin")]
        [HttpPut]
        public async Task<BaseActionResult<bool>> Update([FromBody] UpdateProductRequest request)
        {
            var result = await _productService.Update(request);
            return result.Match(
                success => Ok(success),
                error => BadRequest(error)
            );
        }

        [Authorize (Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<BaseActionResult<bool>> Delete(Guid id)
        {
            var result = await _productService.Delete(id);
            return result.Match(
                success => Ok(success),
                error => BadRequest(error)
            );
        }
    }
}
