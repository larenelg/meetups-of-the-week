using System.Collections.Generic;
using DataDrivenDiversity.Models.Domain;

namespace DataDrivenDiversity.Models.View
{
    public class GroupsViewModel
    {
        public IEnumerable<MeetupGroup> Groups { get; set; }
    }
}