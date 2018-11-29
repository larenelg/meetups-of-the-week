using System.Collections.Generic;
using DataDrivenDiversity.Models.Domain;

namespace DataDrivenDiversity.Models.View
{
    public class EventsViewModel
    {
        public IEnumerable<MeetupEvent> Events { get; set; }
    }
}