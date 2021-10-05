using System.Collections.Generic;

namespace Shop.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        Product GetProductById(int id);
        Product GetProductByName(string name);
        void SaveProduct(Product product);
        Product DeleteProduct(int productId);
    }
}
