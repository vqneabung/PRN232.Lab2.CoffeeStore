using AutoMapper;
using Common;
using OneOf;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;
using PRN232.Lab2.CoffeeStore.Repository.Interfaces;
using PRN232.Lab2.CoffeeStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<OneOf<bool, BaseError>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<IEnumerable<UserResponse>, BaseError>> GetAlls()
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<UserResponse, BaseError>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
