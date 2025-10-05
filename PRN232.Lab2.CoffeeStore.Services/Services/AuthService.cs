using AutoMapper;
using Common;
using Microsoft.AspNetCore.Identity;
using OneOf;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;
using PRN232.Lab2.CoffeeStore.Repositories.Entities;
using PRN232.Lab2.CoffeeStore.Repositories.Interfaces;
using PRN232.Lab2.CoffeeStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<OneOf<TokenResponse, BaseError>> LoginAsync(Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email!);
            if (user == null)
                return (BaseError)"User not found"; 

            if (!user.IsActive)
                return (BaseError)"User is inactive";

            var tokenResponse = await GenerateTokenResponseAsync(user);
            return tokenResponse;
        }

        public async Task<OneOf<TokenResponse, BaseError>> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var user = await _unitOfWork.Auths.ValidateRefreshToken(request.UserId, request.RefreshToken);
            if (user == null)
                return (BaseError)"Invalid refresh token";
            var tokenResponse = await GenerateTokenResponseAsync(user);
            return tokenResponse;
        }

        public async Task<OneOf<string, BaseError>> RegisterAsync(RegisterRequest register, string role)
        {
            var emailExists = await CheckEmailExists(register.Email!);
            if (emailExists)
                return (BaseError)"Email already exists";

            var user = _mapper.Map<User>(register);

            var createResult = await _userManager.CreateAsync(user, register.Password!);
            if (!createResult.Succeeded)
                return (BaseError)string.Join(", ", createResult.Errors.Select(e => e.Description));
            var roleResult = await _userManager.AddToRoleAsync(user, role);
            if (!roleResult.Succeeded)
                return (BaseError)string.Join(", ", roleResult.Errors.Select(e => e.Description));

            return "User registered successfully";

        }

        private async Task<TokenResponse> GenerateTokenResponseAsync(User user)
        {
            var role = (await _userManager.GetRolesAsync(user))[0];
            return new TokenResponse()
            {
                AccessToken = _unitOfWork.Auths.GenerateJwtToken(user, role),
                RefreshToken = await _unitOfWork.Auths.GenerateAndSaveRefreshToken(user)
            };
        }

        private async Task<bool> CheckEmailExists(string email)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            return existingUser != null;
        }
    }
}
