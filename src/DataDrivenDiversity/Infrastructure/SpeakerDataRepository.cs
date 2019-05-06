using System.Linq;
using DataDrivenDiversity.Models.Domain;
using Hammock;

namespace DataDrivenDiversity.Infrastructure
{
    public class SpeakerDataRepository
    {
        public void SaveSpeakerData(string eventId, SpeakerData speakerData)
        {
            var db = new Connection(new System.Uri("http://db.localtest.me:5984"));

            if (!db.ListDatabases().Contains("speaker-data")) 
            { 
                db.CreateDatabase("sample-db"); 
            }
            
            using (var s = db.CreateSession("speaker-data"))
            {
                var result = s.Save<SpeakerDataStore>(new SpeakerDataStore { Id = eventId, Data = speakerData });
            }
        }

        public SpeakerData LoadSpeakerData(string eventId)
        {
            SpeakerData result = null;

            var db = new Connection(new System.Uri("http://db.localtest.me:5984"));
            
            using (var s = db.CreateSession("speaker-data"))
            {
                var response = s.Load<SpeakerDataStore>(eventId);
                result = response.Data;
            }

            return result;
        }

        public class SpeakerDataStore
        {
            public string Id { get; set; }
            public SpeakerData Data { get; set; }
        }
    }
}