using System.Collections.Generic;
using DataDrivenDiversity.Models.Domain;

namespace DataDrivenDiversity.Models.View
{
    public class CategoriesViewModel
    {
        public IEnumerable<MeetupCategory> Categories { get; set; }
    }
}