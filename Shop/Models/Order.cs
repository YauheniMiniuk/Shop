using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage ="Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Введите первую строку адреса")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage ="Введите название города")]
        public string City { get; set; }
        [Required(ErrorMessage ="Введите название области")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage ="Введите название страны")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
