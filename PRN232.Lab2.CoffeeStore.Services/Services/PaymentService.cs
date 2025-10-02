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

        public Task<OneOf<bool, BaseError>> CreateAsync(CreatePaymentRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<bool, BaseError>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<PagedResponse<PaymentResponse>, BaseError>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<PaymentResponse, BaseError>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
