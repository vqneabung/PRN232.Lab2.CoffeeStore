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

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OneOf<bool, BaseError>> Create(CreateCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            try
            {
                await _unitOfWork.Categories.AddAsync(category);
                await _unitOfWork.Categories.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }

        }

        public async Task<OneOf<IEnumerable<CategoryResponse>, BaseError>> GetAlls()
        {
            try 
            {
                var categories = await _unitOfWork.Categories.GetAllAsync();
                var categoryResponses = _mapper.Map<IEnumerable<CategoryResponse>>(categories);
                return categoryResponses.ToList();
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<CategoryResponse, BaseError>> GetById(Guid id)
        {
            try
            {
                var category = await _unitOfWork.Categories.GetByIdAsync(c => c.CategoryId == id);
                if (category == null)
                {
                    return (BaseError)"Category not found";
                }
                var categoryResponse = _mapper.Map<CategoryResponse>(category);
                return categoryResponse;
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }

        }
        public async Task<OneOf<bool, BaseError>> Update(UpdateCategoryRequest request)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(c => c.CategoryId == request.CategoryId);
            if (category == null)
            {
                return (BaseError)"Category not found";
            }
            _mapper.Map(request, category);
            try
            {
                _unitOfWork.Categories.Update(category);
                await _unitOfWork.Categories.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }
    }
}
