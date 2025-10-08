using Common;
using Common.DTOs.Request;
using OneOf;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Request;
using PRN232.Lab2.CoffeeStore.Repositories.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Services.Interfaces
{
    public interface IProductService
    {
        Task<OneOf<IEnumerable<ProductResponse>, BaseError>> GetPagedAsync(SearchPagedSortedRequest request);

        Task<OneOf<ProductResponse, BaseError>> GetById(Guid id);

        Task<OneOf<bool, BaseError>> Create(CreateProductRequest productDto);

        Task<OneOf<bool, BaseError>> Update(UpdateProductRequest productDto);

        Task<OneOf<bool, BaseError>> Delete(Guid id);
    }
}
