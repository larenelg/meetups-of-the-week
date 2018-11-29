using Refit;

namespace DataDrivenDiversity.Models.Domain
{
    public class MeetupOrganizer
    {
        [AliasAs("id")]
        public int Id { get; set; }
        [AliasAs("name")]
        public string Name { get; set; }
        [AliasAs("bio")]
        public string Bio { get; set; }
        [AliasAs("photo")]
        public MeetupPhoto Photo { get; set; }
        
    }
}