using System;
using DataDrivenDiversity.Models.Helpers;
using Newtonsoft.Json;
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

        [JsonConverter (typeof(MillisecondEpochConverter))]
        public DateTime Created { get; set; }
        [AliasAs("description")]
        public string Description { get; set; }
    }
}