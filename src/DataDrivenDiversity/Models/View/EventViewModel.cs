using System.Collections.Generic;
using DataDrivenDiversity.Models.Domain;

namespace DataDrivenDiversity.Models.View
{
    public class EventViewModel
    {   
        public string GroupUrlName { get; set; }
        public MeetupEvent Event { get; set; }
    }
}