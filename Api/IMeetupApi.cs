using System.Threading.Tasks;
using DataDrivenDiversity.Api.Models;
using DataDrivenDiversity.Models.Domain;
using Refit;

namespace DataDrivenDiversity.Api
{
    public interface IMeetupApi
    {
        [Get("/2/categories")]
         Task<MeetupResponse<MeetupCategory>> GetCategories();

         [Get("/2/cities")]
         Task<MeetupResponse<MeetupCity>> GetCities();

         [Get("/2/cities")]
         Task<MeetupResponse<MeetupCity>> SearchCities(CitiesQueryParams query);

         [Get("/2/groups")]
         Task<MeetupResponse<MeetupGroup>> SearchGroups(GroupsQueryParams query);
    }
}