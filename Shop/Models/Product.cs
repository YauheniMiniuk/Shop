using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите категорию")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Укажите цену")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Укажите положительное значение для цены")]
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
