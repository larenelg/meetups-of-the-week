using System.Threading.Tasks;
using DataDrivenDiversity.Api.Models;
using DataDrivenDiversity.Models.Domain;
using Refit;

namespace DataDrivenDiversity.Api
{
    public interface IGenderApi
    {
        [Get("/?name={firstName}")]
         Task<MeetupResponse<MeetupCategory>> GetGenderOfFirstName();
    }
}