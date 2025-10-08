using AutoMapper;
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
using PRN232.Lab2.CoffeeStore.Repositories.Interfaces;
using Common.Utils;
using Microsoft.EntityFrameworkCore;

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
                product.IsActive = false;
                _unitOfWork.Products.Update(product);
                await _unitOfWork.Products.SaveChangesAsync();
                return true;
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

        public async Task<OneOf<IEnumerable<ProductResponse>, BaseError>> GetPagedAsync(SearchPagedSortedRequest request)
        {
            var keyword = SplitHelper.SplitAndTrim(request.Search!, ',');

            Expression<Func<Product, bool>> filter;
            if (string.IsNullOrEmpty(request.Search))
            {
                filter = p => p.IsActive == true;
            }
            else
            {
                filter = p => p.IsActive == true && keyword.Any(k =>
                    // Search by Product Name
                    (p.Name != null && p.Name.Contains(k)) ||
                    // Search by Description
                    (p.Description != null && p.Description.Contains(k)) ||
                    // Search by Category Name
                    (p.Category != null && p.Category.Name != null && p.Category.Name.Contains(k)) ||
                    // Search by Price (exact or contains)
                    p.Price.ToString().Contains(k)
                );
            }

            try
            {
                var (products, totalCount) = await _unitOfWork.Products.GetPagedAsync(
                    pageNumber: request.PageNumber,
                    pageSize: request.PageSize,
                    asNoTracking: true,
                    include: query => query.Include(p => p.Category),
                    filter: filter
                );
                
                var productResponses = _mapper.Map<IEnumerable<ProductResponse>>(products);
                var pagedResponse = PagedResponse<ProductResponse>.Response(productResponses.ToList(), totalCount, request.PageNumber, request.PageSize);
                return pagedResponse.Data ?? new List<ProductResponse>();
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
