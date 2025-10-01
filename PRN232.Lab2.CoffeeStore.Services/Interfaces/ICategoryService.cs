
namespace PRN232.Lab2.CoffeeStore.Services.Interfaces
{
    public interface ICategoryService
    { 
        Task<IEnumerable<CategoryResponse> GetAlls();
        Task<CategoryResponse?> GetById(int id);
    }
}
