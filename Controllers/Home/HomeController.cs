using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataDrivenDiversity.Api;
using DataDrivenDiversity.Models.View;
using DataDrivenDiversity.Api.Models;

namespace DataDrivenDiversity.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IMeetupApi _Api;

        public HomeController(IMeetupApi _api)
        {
            _Api = _api;
        }
        public IActionResult Index(GroupsQueryParams query)
        {
            if (query.CategoryId == 0)
            {
                query = new GroupsQueryParams {
                    Country = "Australia",
                    Lat = "-27.470125",
                    Lon = "153.021072",
                    Radius = 10,
                    CategoryId = 34
                };
            }

            var groups = _Api.SearchGroups(query).Result;

            var model = new GroupsViewModel { Groups = groups.Results, Query = query };
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(GroupsQueryParams query)
        {
            return RedirectToAction("Index", query);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
