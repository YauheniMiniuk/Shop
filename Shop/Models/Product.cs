using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Еблан, забыл написать имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Еблан, забыл написать категорию")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Еблан, забыл написать цену")]
        public decimal? Price { get; set; }
        public string Description { get; set; }
    }
}
