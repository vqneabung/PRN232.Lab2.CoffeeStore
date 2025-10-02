using PRN232.Lab2.CoffeeStore.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        public string GenerateJwtToken(User user, string role);
        public Task<string> GenerateAndSaveRefreshToken(User user);
        public Task<User> ValidateRefreshToken(Guid userId, string refreshToken);
    }
}
