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

         [Get("/2/groups?only=members,name,urlname,id,created")]
         Task<MeetupResponse<MeetupGroup>> SearchGroups(GroupsQueryParams query);

         [Get("/{urlname}?only=id,name,status,link,urlname,description,created,members,organizer")]
         Task<MeetupGroupDetails> GetGroup(string urlname);

        [Get("/2/events?group_urlname={urlname}&status=past&only=id,name,time,yes_rsvp_count,event_url,status,description")]
        Task<MeetupResponse<MeetupEvent>> GetPastEvents(string urlname);
        // time=1514728800,1543600660&
    }
}