using AutoMapper;
using Common;
using Common.DTOs.Request;
using Common.Utils;
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
    /// Payment service implementation with business logic
    /// </summary>
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OneOf<bool, BaseError>> CreateAsync(CreatePaymentRequest request)
        {
            try
            {
                var payment = _mapper.Map<Payment>(request);
                await _unitOfWork.Payments.AddAsync(payment);
                await _unitOfWork.Payments.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<bool, BaseError>> DeleteAsync(Guid id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(p => p.PaymentId == id);
            if (payment == null)
                return (BaseError)"Payment not found";
            try
            {
                payment.IsActive = false;
                _unitOfWork.Payments.Update(payment);
                await _unitOfWork.Payments.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<PaymentResponse, BaseError>> GetByIdAsync(Guid id)
        {
            try 
            {
                var payment = await _unitOfWork.Payments.GetByIdAsync(p => p.PaymentId == id);
                if (payment == null)
                    return (BaseError)"Payment not found";
                var paymentResponse = _mapper.Map<PaymentResponse>(payment);
                return paymentResponse;
            } catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<PagedResponse<PaymentResponse>, BaseError>> GetPagedAsync(SearchPagedSortedRequest request)
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
                var (payments, totalCount) = await _unitOfWork.Payments.GetPagedAsync(
                     pageNumber: request.PageNumber,
                     pageSize: request.PageSize,
                     filter: p => p.IsActive == true && 
                                 (string.IsNullOrEmpty(request.Search) || 
                                  p.PaymentId.ToString().Contains(request.Search) ||
                                  (p.OrderId != null && p.OrderId.ToString()!.Contains(request.Search)) ||
                                  p.Amount.ToString().Contains(request.Search) ||
                                  (date.HasValue && p.PaymentDate.HasValue && p.PaymentDate.Value.Date == date.Value.Date) ||
                                  (p.PaymentMethod != null && p.PaymentMethod.Contains(request.Search))));

                var paymentResponses = _mapper.Map<IEnumerable<PaymentResponse>>(payments);
                return PagedResponse<PaymentResponse>.Response(paymentResponses.ToList(), request.PageNumber, request.PageSize, totalCount);
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }
    }
}
