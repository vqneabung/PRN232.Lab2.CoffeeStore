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
using Common.DTOs.Request;

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

        public async Task<OneOf<bool, BaseError>> Create(CreateProductRequest productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                await _unitOfWork.Products.AddAsync(product);
                await _unitOfWork.Products.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<bool, BaseError>> Delete(Guid id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(p => p.ProductId == id);
            if (product == null)
                return (BaseError)"Product not found";
            try
            {
                _unitOfWork.Products.Remove(product);
                await _unitOfWork.Products.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<IEnumerable<ProductResponse>, BaseError>> GetAlls(PagedAndSortedRequest pagedAndSortedRequest)
        {
            try
            {
                var (products, totalCount) = await _unitOfWork.Products.GetPagedAsync(
                     pageNumber: pagedAndSortedRequest.PageNumber,
                     pageSize: pagedAndSortedRequest.PageSize);
                var productResponses = _mapper.Map<IEnumerable<ProductResponse>>(products);
                return productResponses.ToList();
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<ProductResponse, BaseError>> GetById(Guid id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(p => p.ProductId == id);
            if (product == null)
                return (BaseError)"Product not found";
            try
            {
                var productResponse = _mapper.Map<ProductResponse>(product);
                return productResponse;
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }

        public async Task<OneOf<bool, BaseError>> Update(UpdateProductRequest productDto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(p => p.ProductId == productDto.ProductId);
            if (product == null)
                return (BaseError)"Product not found";
            try
            {
                _mapper.Map(productDto, product);
                _unitOfWork.Products.Update(product);
                await _unitOfWork.Products.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return (BaseError)ex.Message;
            }
        }
    }
}
