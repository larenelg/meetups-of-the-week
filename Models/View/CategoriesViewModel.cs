using System.Collections.Generic;
using DataDrivenDiversity.Models.Domain;

namespace DataDrivenDiversity.Models.View
{
    internal class CategoriesViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}