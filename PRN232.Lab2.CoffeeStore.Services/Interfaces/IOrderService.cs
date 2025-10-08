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
        Task<OneOf<PagedResponse<OrderResponse>, BaseError>> GetPagedAsync(SearchPagedSortedRequest request);
        Task<OneOf<OrderResponse, BaseError>> GetByIdAsync(Guid id);
        Task<OneOf<PagedResponse<OrderResponse>, BaseError>> GetAllOrdersByUserIdAsync(Guid userId, SearchPagedSortedRequest request);
        Task<OneOf<IEnumerable<OrderDetailResponse>, BaseError>> GetOrderDetailByOrderIdAsync(Guid orderId);
        Task<OneOf<bool, BaseError>> CreateAsync(CreateOrderRequest request);
        Task<OneOf<bool, BaseError>> DeleteAsync(Guid id);
    }
}
