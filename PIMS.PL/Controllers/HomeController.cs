using Microsoft.AspNetCore.Mvc;
using PIMS.BLL.Services.CategoryServices;
using PIMS.BLL.Services.ProductServices;
using PIMS.PL.Models;
using System.Diagnostics;

namespace PIMS.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ViewBag.TotalProducts = _productService.GetAllProducts().Count();
            ViewBag.TotalCategories = _categoryService.GetAllCategories().Count();
            ViewBag.TotalValue = _productService.GetAllProducts().Sum(p => p.Price * p.Quantity);
            return View();
        }
    }
}
