using System.Threading.Tasks;
using DataDrivenDiversity.Api.Models;
using DataDrivenDiversity.Models.Domain;
using Refit;

namespace DataDrivenDiversity.Api
{
    public interface IMeetupApi
    {
        [Get("/2/categories")]
         Task<MeetupResponse<Category>> GetCategories();
    }
}