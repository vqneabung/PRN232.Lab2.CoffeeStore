using Common;
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
    public interface IPaymentService
    {
        Task<OneOf<PagedResponse<PaymentResponse>, BaseError>> GetAllAsync();
        Task<OneOf<PaymentResponse, BaseError>> GetByIdAsync(int id);
        Task<OneOf<bool, BaseError>> CreateAsync(CreatePaymentRequest request);
        Task<OneOf<bool, BaseError>> DeleteAsync(int id);   
    }
}
