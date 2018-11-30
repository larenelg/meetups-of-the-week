using System.Collections.Generic;
using DataDrivenDiversity.Api.Models;
using DataDrivenDiversity.Models.Domain;

namespace DataDrivenDiversity.Models.View
{
    public class GroupsViewModel
    {
        public IEnumerable<MeetupGroup> Groups { get; set; }
        public GroupsQueryParams Query { get; set; }
        public int TotalGroups { get; set; }
    }
}