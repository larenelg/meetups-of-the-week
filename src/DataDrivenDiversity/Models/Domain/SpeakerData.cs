using System.Collections.Generic;

namespace DataDrivenDiversity.Models.Domain
{
    public class SpeakerData
    {
        public IEnumerable<string> Names { get; set; }
        public IEnumerable<string> Pronouns { get; set; }
    }
}