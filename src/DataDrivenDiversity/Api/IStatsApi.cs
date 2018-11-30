using System.Threading.Tasks;
using DataDrivenDiversity.Models.Domain;
using Refit;

namespace DataDrivenDiversity.Api
{
    public interface IStatsApi
    {
        [Post("/extract-speaker")]
        Task<SpeakerData> ExtractSpeaker([Body] string text);
    }
}