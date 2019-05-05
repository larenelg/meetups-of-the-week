using System.Threading.Tasks;
using DataDrivenDiversity.Models.Domain;
using Refit;

namespace DataDrivenDiversity.Api
{
    public interface INerApi
    {
        [Post("/?properties={\"annotators\": \"tokenize,ssplit,ner\", \"date\": \"2019-05-05T08:37:34\"}&pipelineLanguage=en")]
        Task<SpeakerData> ExtractSpeaker([Body] string text);
    }
}
