using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Application.Dtos.Request;
using ProductManagement.Application.Dtos.Response;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto createProductDto
            )
        {
            var productEntity = new Product
            {
                Id = Guid.NewGuid(),
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
            };
            var newProduct = await _productRepository.AddProductAsync(productEntity);
            return MapEntityToDto(newProduct);
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return false;
            }
            await _productRepository.DeleteAsync(id);
            return true;

        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => MapEntityToDto(p));

        }

        public async Task<ProductDto?> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) {
                return null;
            }
            return MapEntityToDto(product);
        }

        public async Task<bool> UpdateProductAsync(Guid id, UpdateProductDto updateProductDto)
        {
            var existProduct = await _productRepository.GetByIdAsync(id);
            if (existProduct == null)
            {
                return false;
            }
            existProduct.Name = updateProductDto.Name;
            existProduct.Description = updateProductDto.Description;
            existProduct.Price = updateProductDto.Price;
            await _productRepository.UpdateAsync(existProduct);
            return true;
        }

        private ProductDto MapEntityToDto(Product product) {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };
        }
    }
}
