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

        public Task<bool> Create(CreateProductRequest productDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductResponse>> GetAlls()
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateProductRequest productDto)
        {
            throw new NotImplementedException();
        }
    }
}
