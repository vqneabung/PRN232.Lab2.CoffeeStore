
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;

namespace PRN232.Lab2.CoffeeStore.Services.Interfaces
{
    public interface ICategoryService
    { 
        Task<IEnumerable<CategoryResponse>> GetAlls();
        Task<CategoryResponse?> GetById(int id);
        Task<bool> Create(CreateCategoryRequest request);
        Task<bool> Update(int id, UpdateCategoryRequest request);
    }
}
