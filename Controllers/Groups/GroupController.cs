using System;
using DataDrivenDiversity.Api;
using DataDrivenDiversity.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace DataDrivenDiversity.Controllers.Groups
{
    [Route("[controller]")]
    public class GroupController : Controller
    {
        private readonly IMeetupApi _Api;

        public GroupController(IMeetupApi _api)
        {
            _Api = _api;
        }

        [Route("{urlname}")]
        public IActionResult Index(string urlname)
        {
            var group = _Api.GetGroup(urlname).Result;
            var model = new GroupViewModel
            {
                Name = group.Name,
                Url = group.Link,
                Members = group.Members,
                Description = group.Description,
                Created = new DateTime(group.Created),
                Organiser = group.Organizer.Name
            };

            return View(model);
        }
    }
}