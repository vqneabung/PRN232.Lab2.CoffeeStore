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
    public interface IUserService
    {
        Task<OneOf<IEnumerable<UserResponse>, BaseError>> GetAlls();

        Task<OneOf<UserResponse, BaseError>> GetById(Guid id);

        Task<OneOf<bool, BaseError>> Delete(Guid id);
    }
}
