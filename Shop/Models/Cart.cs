using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.ProductId == product.Id)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    Quantity = quantity
                });
            }
            else
                line.Quantity += quantity;
        }
        public virtual void RemoveLine(Product product) =>
            lineCollection.RemoveAll(l => l.ProductId == product.Id);
        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(e => e.ProductPrice * e.Quantity);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
    public class CartLine
    {
        public int Id { get; set; }
        //public Product Product { get; set; }
        //
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        //
        public int Quantity { get; set; }
    }
}
