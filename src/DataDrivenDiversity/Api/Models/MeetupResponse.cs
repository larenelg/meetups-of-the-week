using System.Collections.Generic;
using Newtonsoft.Json;

namespace DataDrivenDiversity.Api.Models
{
    public class MeetupResponse<T>
    {
        public IEnumerable<T> Results { get; set; }
        public Meta Meta { get; set; }
    }

    public class Meta
    {
        public string Next { get; set; }
        public string Method { get; set; }
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
        public string Link { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public string Lon { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string SignedUrl { get; set; }
        public string Id { get; set; }
        public string Updated { get; set; }
        public string Lat { get; set; }
    }
}