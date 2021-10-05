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

        public ViewResult Product(string productName)
        {
            var product = productRepository.GetProductByName(productName);
            if (product == null)
            {
                return View("Error");
            }
            return View(product);
        }

    }
}
