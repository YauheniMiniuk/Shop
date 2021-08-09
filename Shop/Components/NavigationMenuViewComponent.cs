using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Shop.Models;
using System.Linq;
using Shop.Models.ViewModels;

namespace Shop.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            ViewBag.SelectedSubcategory = RouteData?.Values["subcategory"];
            return View(new CategoriesSubcategoriesViewModel
            {
                Categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x),
                Subcategories = repository.Products
                .Where(x=>x.Category == ViewBag.SelectedCategory)
                .Select(x => x.Subcategory)
                .Distinct()
                .OrderBy(x => x)
            });
        }
    }
}
