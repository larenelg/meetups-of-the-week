using Refit;

namespace DataDrivenDiversity.Models.Domain
{
    public class MeetupGroup
    {
        [AliasAs("name")]
        public string Name { get; set; }
        [AliasAs("id")]
        public int Id { get; set; }
        [AliasAs("urlname")]
        public string UrlName { get; set; }
        [AliasAs("members")]
        public int Members { get; set; }
    }
}