using PIMS.BLL.DTO.CategoryDto_s;
using PIMS.BLL.DTO.ProductDto_s;
using System.Collections.Generic;

namespace PIMS.BLL.Services.CategoryServices
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDto GetCategoryById(int id);
        void AddCategory(CreateCategoryDto dto);
        void UpdateCategory(UpdateCategoryDto dto);
        void DeleteCategory(int id);
    }
}
