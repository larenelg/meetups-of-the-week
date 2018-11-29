using Refit;

namespace DataDrivenDiversity.Models.Domain
{
    public class MeetupGroupDetails : MeetupGroup
    {
        [AliasAs("organizer")]
        public MeetupOrganizer Organizer { get; set; }
        [AliasAs("link")]
        public string Link { get; set; }
        [AliasAs("active")]
        public string Active { get; set; }
        [AliasAs("created")]
        public long Created { get; set; }
        [AliasAs("description")]
        public string Description { get; set; }
    }
}