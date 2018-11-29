using Refit;

namespace DataDrivenDiversity.Api.Models
{
    public class CitiesQueryParams
    {
        [AliasAs("country")]
        public string Country { get; set; }

        [AliasAs("lat")]

        public string Lat { get; set; }

        [AliasAs("lon")]
        public string Lon { get; set; }

        [AliasAs("radius")]
        public int Radius { get; set; }
    }
}