using PRN232.Lab1.CoffeeStore.Core.DTOs.Request;
using PRN232.Lab1.CoffeeStore.Core.DTOs.Response;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAlls();

        Task<ProductResponse?> GetById(int id);

        Task<bool> Create(CreateProductRequest productDto);

        Task<bool> Update(UpdateProductRequest productDto);

        Task<bool> Delete(int id);
    }
}
