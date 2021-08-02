using System.Collections.Generic;

namespace Shop.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        Product GetProductById(int id);
        void SaveProduct(Product product);
    }
}
