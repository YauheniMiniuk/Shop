using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.ViewModels
{
    public class CategoriesSubcategoriesViewModel
    {
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<string> Subcategories { get; set; }
    }
}
