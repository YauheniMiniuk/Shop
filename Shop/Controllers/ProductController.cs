using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Product(int id)
        {
            return View(productRepository.GetProductById(id));
        }
    }
}
