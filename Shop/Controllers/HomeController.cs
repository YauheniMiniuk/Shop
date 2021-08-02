using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Models.ViewModels;
using System.Linq;

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
        [Route("")]
        [Route("{category}")]
        [Route("{category}/Page{productPage}")]
        public ViewResult Index(string category, int productPage = 1) =>
            View(new ProductsListViewModel
            {
                Products = productRepository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.Name)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemPerPage = PageSize,
                    TotalItems = category == null ?
                        productRepository.Products.Count() :
                        productRepository.Products.Where(p => p.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}
