using App.Service;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public string Index()
        {
            _logger.LogInformation("Index Action");
            return "Tôi là Index của First";
        }

        public void Nothing()
        {
            _logger.LogInformation("Nothing Action");
            this.Response.Headers.Add("Hi", "Xin chào các bạn");
        }

        public object Anything() => DateTime.Now;

        public IActionResult Readme()
        {
            return Content("Xin chào các bạn", "text/plain");
        }

        public IActionResult MarkLeo()
        {
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "MarkLeo.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/jpg");
        }

        public IActionResult IphonePrice()
        {
            return Json(
                new
                {
                    productName = "Iphone",
                    Price = 1000
                }
            );
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyển hướng đến " + url);
            return LocalRedirect(url); // Phải đảm bảo địa chỉ là local, trong url không có phần host
        }

        public IActionResult RedirectToGoogle()
        {
            var url = "https://www.google.com/";
            _logger.LogInformation("Chuyển hướng đến " + url);
            return Redirect(url);
        }

        public IActionResult HelloView(string username = "Guest")
        {
            // View() => Razor Engine, đọc và thi hành file .cshtml (template)
            // return View("/MyView/XinChao1.cshtml", username);
            // return View("XinChao2", username);
            return View("xinchao3", username);
        }

        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}