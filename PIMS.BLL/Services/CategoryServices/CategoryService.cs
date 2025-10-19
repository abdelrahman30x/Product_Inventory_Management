using PIMS.BLL.DTO.CategoryDto_s;
using PIMS.DAL.Models.Category;
using PIMS.DAL.Repositories.CategoryRepo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PIMS.BLL.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll().ToList();

            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public CategoryDto GetCategoryById(int id)
        {
            var category = _categoryRepository.GetByID(id);
            if (category == null)
                return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public void AddCategory(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            _categoryRepository.Add(category);
        }

        public void UpdateCategory(UpdateCategoryDto dto)
        {
            var existing = _categoryRepository.GetByID(dto.Id);
            if (existing == null)
                return;

            existing.Name = dto.Name;

            _categoryRepository.Update(existing);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }
    }
}
