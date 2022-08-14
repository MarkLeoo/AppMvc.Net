using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Service;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Area("ProductMange")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        // /Areas/AreaName/Views/Controller/Action
        [Route("/cac-san-pham/{id?}")]
        public IActionResult Index()
        {
            // /Areas/ProductManage/Views/product/Index
            var product = _productService.OrderBy(p => p.Name).ToList();
            return View(product);
        }
    }
}