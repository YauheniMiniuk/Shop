using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;
using Shop.Models.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        IProductRepository productRepository;
        public int PageSize = 4;
        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public ViewResult Index(int productPage = 1) =>
            View(new ProductsListViewModel
            {
                Products = productRepository.Products
                .OrderBy(p => p.Name)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemPerPage = PageSize,
                    TotalItems = productRepository.Products.Count()
                }
            });
                
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.AddProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
    }
}
