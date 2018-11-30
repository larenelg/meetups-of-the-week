using System.Collections.Generic;
using DataDrivenDiversity.Models.Domain;

namespace DataDrivenDiversity.Models.View
{
    public class EventsViewModel
    {
        public string GroupUrlName { get; set; }
        public IEnumerable<MeetupEvent> Events { get; set; }
    }
}