using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Application.Dtos.Request;
using ProductManagement.Application.Dtos.Response;

namespace ProductManagement.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateAsync(CreateProductDto createProductDto);
        Task<ProductDto?> GetProductByIdAsync(Guid id);
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<bool> UpdateProductAsync(Guid id, UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
