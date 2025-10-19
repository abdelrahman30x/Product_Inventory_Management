using PIMS.BLL.DTO.ProductDto_s;
using System.Collections.Generic;

namespace PIMS.BLL.Services.ProductServices
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductById(int id);
        void AddProduct(CreateProductDto dto);
        void UpdateProduct(UpdateProductDto dto);
        void DeleteProduct(int id);
    }
}
