using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Products);
        [HttpPost]
        public IActionResult SeedDatabase()
        {
            //SeedData.EnsurePopulated(HttpContext.RequestServices);
            return RedirectToAction(nameof(Index));
        }
        public ViewResult Create() => View("Edit", new Product());
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
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Product deletedProduct = repository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = $"Продукт {deletedProduct.Name} был удален";
            }
            return RedirectToAction("Index");
        }
    }
}
