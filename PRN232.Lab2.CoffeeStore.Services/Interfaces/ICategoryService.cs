
using Common;
using OneOf;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;

namespace PRN232.Lab2.CoffeeStore.Services.Interfaces
{
    public interface ICategoryService
    { 
        Task<OneOf<IEnumerable<CategoryResponse>, BaseError>> GetAlls();
        Task<OneOf<CategoryResponse, BaseError>> GetById(int id);
        Task<OneOf<bool, BaseError>> Create(CreateCategoryRequest request);
        Task<OneOf<bool, BaseError>> Update(int id, UpdateCategoryRequest request);
    }
}
