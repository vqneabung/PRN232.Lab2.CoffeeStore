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
    public interface IPaymentService
    {
        Task<PagedResponse<PaymentResponse>> GetAllAsync();
        Task<PaymentResponse?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreatePaymentRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
