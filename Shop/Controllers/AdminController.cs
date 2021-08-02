using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System.Linq;

namespace Shop.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Products);
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.Id == productId));
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"Продукт \"{product.Name}\" был сохранён";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }
    }
}
