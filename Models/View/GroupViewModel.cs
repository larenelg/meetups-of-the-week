using System;

namespace DataDrivenDiversity.Models.View
{
    public class GroupViewModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Members { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string Organiser { get; set; }
    }
}