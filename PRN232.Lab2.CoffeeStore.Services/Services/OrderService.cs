using AutoMapper;
using Common;
using Common.DTOs.Request;
using OneOf;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;
using PRN232.Lab2.CoffeeStore.Repositories.Entities;
using PRN232.Lab2.CoffeeStore.Repositories.Interfaces;
using PRN232.Lab2.CoffeeStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Services.Services
{
    /// <summary>
    /// Order service implementation with business logic
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public async Task<OneOf<bool, BaseError>> CreateAsync(CreateOrderRequest request)
        {
            var order = _mapper.Map<Order>(request);
            try
            {
                await _unitOfWork.Orders.AddAsync(order);
                await _unitOfWork.Orders.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<bool, BaseError>> DeleteAsync(Guid id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(o => o.OrderId == id);
            if (order == null)
                return (BaseError)"Order not found";
            try
            {
                order.IsActive = false; 
                _unitOfWork.Orders.Update(order);
                await _unitOfWork.Orders.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;

            }
        }

        public async Task<OneOf<PagedResponse<OrderResponse>, BaseError>> GetAllAsync(PagedAndSortedRequest pagedAndSortedRequest)
        {
            try
            {
                var (orders, totalCount) = await _unitOfWork.Orders.GetPagedAsync(
                  pageNumber: pagedAndSortedRequest.PageNumber,
                  pageSize: pagedAndSortedRequest.PageSize,
                  asNoTracking: true
                );
                var orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(orders);
                return PagedResponse<OrderResponse>.Ok(orderResponses.ToList(), totalCount, pagedAndSortedRequest.PageNumber, pagedAndSortedRequest.PageSize);
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<OrderResponse, BaseError>> GetByIdAsync(Guid id)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(o => o.OrderId == id);
                if (order == null)
                    return (BaseError)"Order not found";
                return _mapper.Map<OrderResponse>(order);
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }
    }
}
