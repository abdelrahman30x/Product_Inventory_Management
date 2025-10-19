using Microsoft.AspNetCore.Mvc;
using PIMS.BLL.DTO.CategoryDto_s;
using PIMS.BLL.Services.CategoryServices;
using PIMS.BLL.Services.ProductServices;

namespace PIMS.PL.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }

        public IActionResult Details(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            _categoryService.AddCategory(dto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();

            var dto = new UpdateCategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            _categoryService.UpdateCategory(dto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
