using Common.DTOs.Request;
using Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<BaseActionResult<IEnumerable<ProductResponse>>> GetAll(PagedAndSortedRequest request)
        {
            var result = await _productService.GetAlls(request);
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



    }
}
