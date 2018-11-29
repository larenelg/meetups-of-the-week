using System.Collections.Generic;
using DataDrivenDiversity.Models.Domain;

namespace DataDrivenDiversity.Models.View
{
    public class CitiesViewModel
    {
        public IEnumerable<MeetupCity> Cities { get; set; }
    }
}