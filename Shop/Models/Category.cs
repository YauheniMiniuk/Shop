using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Category
    {
        public string CategoryName { get; set; }
        public List<string> Subcategories { get; set; }
    }
}
