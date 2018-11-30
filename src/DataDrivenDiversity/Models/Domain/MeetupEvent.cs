using System;
using DataDrivenDiversity.Models.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;

namespace DataDrivenDiversity.Models.Domain
{
    public class MeetupEvent
    {
        [AliasAs("id")]
        public string Id { get; set; }

        [AliasAs("name")]
        public string Name { get; set; }

        [AliasAs("time")]
        [JsonConverter (typeof(MillisecondEpochConverter))]
        public DateTime Time { get; set; }

        [AliasAs("yes_rsvp_count")]
        [JsonProperty("yes_rsvp_count")]
        public int YesRsvpCount { get; set; }

        [AliasAs("event_url")]
        [JsonProperty("event_url")]
        public string EventUrl { get; set; }

        [AliasAs("status")]
        public string Status { get; set; }

        [AliasAs("description")]
        public string Description { get; set; }
    }
}