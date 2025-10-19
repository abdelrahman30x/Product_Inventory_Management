using Microsoft.AspNetCore.Mvc;
using PIMS.BLL.DTO.ProductDto_s;
using PIMS.BLL.Services.ProductServices;
using PIMS.BLL.Services.CategoryServices;

namespace PIMS.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _categoryService.GetAllCategories();
                return View(dto);
            }

            _productService.AddProduct(dto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            var dto = new UpdateProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryId = product.CategoryId
            };

            ViewBag.Categories = _categoryService.GetAllCategories();
            return View(dto);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _categoryService.GetAllCategories();
                return View(dto);
            }

            _productService.UpdateProduct(dto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
