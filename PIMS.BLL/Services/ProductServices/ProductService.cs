using PIMS.BLL.DTO.ProductDto_s;
using PIMS.DAL.Models.Product;
using PIMS.DAL.Repositories.ProductRepo;
using System.Collections.Generic;
using System.Linq;

namespace PIMS.BLL.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _productRepository.GetAll().ToList();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,               
                CategoryName = p.Category?.Name ?? ""   
            });
        }

        public ProductDto GetProductById(int id)
        {
            var product = _productRepository.GetByID(id);
            if (product == null)
                return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,            
                CategoryName = product.Category?.Name ?? "" 
            };
        }

        public void AddProduct(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Quantity = dto.Quantity,   
                CategoryId = dto.CategoryId
            };

            _productRepository.Add(product);
        }

        public void UpdateProduct(UpdateProductDto dto)
        {
            var existing = _productRepository.GetByID(dto.Id);
            if (existing == null)
                return;

            existing.Name = dto.Name;
            existing.Price = dto.Price;
            existing.Quantity = dto.Quantity;  
            existing.CategoryId = dto.CategoryId;

            _productRepository.Update(existing);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
