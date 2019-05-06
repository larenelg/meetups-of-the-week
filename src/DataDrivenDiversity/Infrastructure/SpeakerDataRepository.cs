using DataDrivenDiversity.Models.Domain;
using Hammock;

namespace DataDrivenDiversity.Infrastructure
{
    public class SpeakerDataRepository
    {
        public void SaveSpeakerData(string eventId, SpeakerData speakerData)
        {
            var db = new Connection(new System.Uri("http://db.localtest.me:5984"));
            
            using (var s = db.CreateSession("speaker-data"))
            {
                var result = s.Save<SpeakerData>(speakerData);
            }
        }

        public SpeakerData LoadSpeakerData(string eventId)
        {
            SpeakerData result = null;

            var db = new Connection(new System.Uri("http://db.localtest.me:5984"));
            
            using (var s = db.CreateSession("speaker-data"))
            {
                result = s.Load<SpeakerData>(eventId);
            }

            return result;
        }
    }
}