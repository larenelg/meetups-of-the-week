using System;
using DataDrivenDiversity.Models.Helpers;
using Newtonsoft.Json;
using Refit;

namespace DataDrivenDiversity.Models.Domain
{
    public class MeetupGroup
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("urlname")]
        public string UrlName { get; set; }

        [JsonProperty("members")]
        public int Members { get; set; }

        [AliasAs("created")]
        [JsonConverter (typeof(MillisecondEpochConverter))]
        public DateTime Created { get; set; }
    }
}