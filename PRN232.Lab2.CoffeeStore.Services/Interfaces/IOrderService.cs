using Azure;
using Common;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Services.Interfaces
{
    public interface IOrderService
    {
        Task<PagedResponse<OrderResponse>> GetAllAsync();
        Task<OrderResponse> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateOrderRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
