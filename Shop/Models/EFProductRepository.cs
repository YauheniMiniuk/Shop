using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class EFProductRepository : IProductRepository
    {
        ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        // Return all products
        public IEnumerable<Product> Products => context.Products;
        public Product GetProductById(int id) => context.Products.Where(p => p.Id == id).FirstOrDefault();
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChangesAsync();
        }
    }
}
