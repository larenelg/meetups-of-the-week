using System.Collections.Generic;
using System.Threading.Tasks;
using DataDrivenDiversity.Models.Domain;
using DataDrivenDiversity.Api.Models;
using Refit;

namespace DataDrivenDiversity.Api
{
    public interface INerApi
    {
        [Post("/")]
        Task<NerRepsonse> Analyse([Body] string text);
    }
}
