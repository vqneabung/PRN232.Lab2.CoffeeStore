using AutoMapper;
using Common;
using Common.DTOs.Request;
using Common.Utils;
using Microsoft.EntityFrameworkCore;
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

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

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

        public async Task<OneOf<PagedResponse<OrderResponse>, BaseError>> GetAllOrdersByUserIdAsync(Guid userId, SearchPagedSortedRequest request)
        {
            var keyword = SplitHelper.SplitAndTrim(request.Search!, ',');

            //if has date 
            DateTime? date = null;
            foreach (var k in keyword)
            {
                if (DateTime.TryParse(k, out var parsedDate))
                {
                    date = parsedDate;
                    break;
                }
            }

            try
            {
                var (orders, totalCount) = await _unitOfWork.Orders.GetPagedAsync(
                  pageNumber: request.PageNumber,
                  pageSize: request.PageSize,
                  asNoTracking: true,
                  include: o => o.Include(o => o.User),
                  filter: o => o.UserId == userId && keyword.Any(k => o.User.UserName!.ToString().Contains(k) ||
                                                (date.HasValue && o.OrderDate.HasValue && o.OrderDate.Value.Date == date.Value.Date) || o.Status.Contains(k) || o.IsActive.ToString()!.ToLower().Contains(k.ToLower()))
                );
                var orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(orders);
                return PagedResponse<OrderResponse>.Response(orderResponses.ToList(), totalCount, request.PageNumber, request.PageSize);
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

        public async Task<OneOf<IEnumerable<OrderDetailResponse>, BaseError>> GetOrderDetailByOrderIdAsync(Guid orderId)
        {
            try
            {
                var orders = await _unitOfWork.Orders.GetByIdAsync(o => o.OrderId == orderId, include: o => o.Include(o => o.OrderDetails));
                if (orders == null)
                    return (BaseError)"Order not found";
                return _mapper.Map<IEnumerable<OrderDetailResponse>>(orders.OrderDetails.ToList()).ToList();
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<PagedResponse<OrderResponse>, BaseError>> GetPagedAsync(SearchPagedSortedRequest request)
        {
            var keyword = SplitHelper.SplitAndTrim(request.Search!, ',');

            //if has date 
            DateTime? date = null;
            foreach (var k in keyword)
            {
                if (DateTime.TryParse(k, out var parsedDate))
                {
                    date = parsedDate;
                    break;
                }
            }

            try
            {
                var (orders, totalCount) = await _unitOfWork.Orders.GetPagedAsync(
                  pageNumber: request.PageNumber,
                  pageSize: request.PageSize,
                  asNoTracking: true,
                  include: o => o.Include(o => o.User),
                  filter: o => keyword.Any(k => o.User.UserName!.ToString().Contains(k) ||
                                                (date.HasValue && o.OrderDate.HasValue && o.OrderDate.Value.Date == date.Value.Date) || o.Status.Contains(k) || o.IsActive == true)
                );
                var orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(orders);
                return PagedResponse<OrderResponse>.Response(orderResponses.ToList(), totalCount, request.PageNumber, request.PageSize);
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }
    }
}
