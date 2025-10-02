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
using OneOf;
using Common;

namespace PRN232.Lab2.CoffeeStore.Services.Services
{
    /// <summary>
    /// Category service implementation with business logic
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Task<OneOf<bool, BaseError>> Create(CreateCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<IEnumerable<CategoryResponse>, BaseError>> GetAlls()
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<CategoryResponse, BaseError>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<bool, BaseError>> Update(int id, UpdateCategoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
