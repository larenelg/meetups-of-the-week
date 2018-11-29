using Refit;

namespace DataDrivenDiversity.Api.Models
{
    public class GroupsQueryParams
    {
        [AliasAs("country")]
        public string Country { get; set; }

        [AliasAs("lat")]

        public string Lat { get; set; }

        [AliasAs("lon")]
        public string Lon { get; set; }

        [AliasAs("radius")]
        public int Radius { get; set; }

        [AliasAs("category_id")]
        public int CategoryId { get; set; }

        [AliasAs("order")]
        public string Order { get; set; } = "members";

        [AliasAs("only")]
        public string Only { get; } = "members,name,urlname,id";
    }
}