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
    public interface IAuthService
    {
        Task<OneOf<string, BaseError>> RegisterAsync(RegisterRequest register, string role);
        Task<OneOf<TokenResponse, BaseError>> LoginAsync(Login login);
        Task<OneOf<TokenResponse, BaseError>> RefreshTokenAsync(RefreshTokenRequest request);
    }
}
