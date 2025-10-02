using AutoMapper;
using PRN232.Lab2.CoffeeStore.Repository.Interfaces;
using PRN232.Lab2.CoffeeStore.Services.Interfaces;
using PRN232.Lab2.CoffeeStore.Repositories.Entities;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Common;
using OneOf;
using Common.DTOs.Request;

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

        public async Task<OneOf<bool, BaseError>> DeleteAsync(Guid id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(p => p.PaymentId == id);
            if (payment == null)
                return (BaseError)"Payment not found";
            try
            {
                _unitOfWork.Payments.Remove(payment);
                await _unitOfWork.Payments.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<PagedResponse<PaymentResponse>, BaseError>> GetAllAsync(PagedAndSortedRequest pagedAndSortedRequest)
        {
            try
            {
                var (payments, totalCount) = await _unitOfWork.Payments.GetPagedAsync(
                     pageNumber: pagedAndSortedRequest.PageNumber,
                     pageSize: pagedAndSortedRequest.PageSize);

                var paymentResponses = _mapper.Map<IEnumerable<PaymentResponse>>(payments);
                return PagedResponse<PaymentResponse>.Ok(paymentResponses.ToList(), pagedAndSortedRequest.PageNumber, pagedAndSortedRequest.PageSize, totalCount);
            } catch (Exception ex)
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
    }
}
