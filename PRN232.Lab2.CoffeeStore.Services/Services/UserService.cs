using AutoMapper;
using Common;
using OneOf;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;
using PRN232.Lab2.CoffeeStore.Repository.Interfaces;
using PRN232.Lab2.CoffeeStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OneOf<bool, BaseError>> Delete(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(u => u.Id == id);
            if (user == null)
                return (BaseError)"User not found";

            try
            {
                _unitOfWork.Users.Remove(user);
                await _unitOfWork.Users.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<IEnumerable<UserResponse>, BaseError>> GetAlls()
        {
            try
            {
                var users = await _unitOfWork.Users.GetAllAsync();
                var userResponses = _mapper.Map<IEnumerable<UserResponse>>(users);
                return userResponses.ToList();
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<UserResponse, BaseError>> GetById(Guid id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(u => u.Id == id);
                return _mapper.Map<UserResponse>(user);
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }

        }
    }
}
