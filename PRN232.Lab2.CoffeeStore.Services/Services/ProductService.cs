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
    /// Product service implementation with business logic
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<OneOf<bool, BaseError>> Create(CreateProductRequest productDto)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<bool, BaseError>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<IEnumerable<ProductResponse>, BaseError>> GetAlls()
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<ProductResponse, BaseError>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<bool, BaseError>> Update(UpdateProductRequest productDto)
        {
            throw new NotImplementedException();
        }
    }
}
