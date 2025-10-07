using Common.DTOs.Request;
using Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;
using PRN232.Lab2.CoffeeStore.Services.Interfaces;

namespace PRN232.Lab2.CoffeeStore.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBaseWithBaseReponse
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<BaseActionResult<IEnumerable<CategoryResponse>>> GetAll()
        {
            var result = await _categoryService.GetAlls();
            return result.Match(
                categories => Ok(categories),
                error => BadRequest(error)
            );
        }

        [HttpGet("{id}")]
        public async Task<BaseActionResult<CategoryResponse>> GetById(Guid id)
        {
            var result = await _categoryService.GetById(id);
            return result.Match(
                category => Ok(category),
                error => BadRequest(error)
            );
        }

        [HttpPost]
        public async Task<BaseActionResult<bool>> Create([FromBody] CreateCategoryRequest request)
        {
            var result = await _categoryService.Create(request);
            return result.Match(
                success => Ok(success),
                error => BadRequest(error)
            );
        }

        [HttpPut]
        public async Task<BaseActionResult<bool>> Update([FromBody] UpdateCategoryRequest request)
        {
            var result = await _categoryService.Update(request);
            return result.Match(
                success => Ok(success),
                error => BadRequest(error)
            );
        }

    }
}
