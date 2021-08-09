using System.Collections.Generic;
using System.Linq;

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
        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.FirstOrDefault(p => p.Id == product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Category = product.Category;
                    dbEntry.Subcategory = product.Subcategory;
                    dbEntry.Price = product.Price;
                    dbEntry.Description = product.Description;
                    dbEntry.isAvailable = product.isAvailable;
                }
            }
            context.SaveChanges();
        }
        public Product DeleteProduct(int productId)
        {
            Product dbEntry = context.Products.FirstOrDefault(p => p.Id == productId);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
