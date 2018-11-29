using Refit;

namespace DataDrivenDiversity.Models.Domain
{
    public class MeetupPhoto
    {
        [AliasAs("id")]
        public int Id { get; set; }
        [AliasAs("photo_link")]
        public string PhotoLink { get; set; }
        [AliasAs("thumb_link")]
        public string ThumbLink { get; set; }
    }
}