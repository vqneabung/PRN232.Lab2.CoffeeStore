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

namespace PRN232.Lab2.CoffeeStore.Services.Services
{
    /// <summary>
    /// Category service implementation with business logic
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> Create(CreateCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryResponse>> GetAlls()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponse?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, UpdateCategoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
