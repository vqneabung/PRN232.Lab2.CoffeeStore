using Azure;
using Common;
using Common.DTOs.Request;
using OneOf;
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
        Task<OneOf<PagedResponse<OrderResponse>, BaseError>> GetAllAsync(PagedAndSortedRequest pagedAndSortedRequest);
        Task<OneOf<OrderResponse, BaseError>> GetByIdAsync(Guid id);
        Task<OneOf<IEnumerable<OrderResponse>, BaseError>> GetAllOrdersByUserIdAsync(Guid userId);
        Task<OneOf<OrderDetailResponse, BaseError>> GetOrderDetailByOrderIdAsync(Guid orderId);
        Task<OneOf<bool, BaseError>> CreateAsync(CreateOrderRequest request);
        Task<OneOf<bool, BaseError>> DeleteAsync(Guid id);
    }
}
