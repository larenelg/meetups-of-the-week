using System.Collections.Generic;
using DataDrivenDiversity.Models.Domain;

namespace DataDrivenDiversity.Models.View
{
    public class SpeakerRatioViewModel
    {
        public List<List<MeetupEvent>> Events { get; set; }
    }
}