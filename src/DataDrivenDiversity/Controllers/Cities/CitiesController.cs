using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataDrivenDiversity.Api;
using DataDrivenDiversity.Models.View;
using DataDrivenDiversity.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataDrivenDiversity.Controllers.Categories
{
    public class CitiesController : Controller
    {
        private readonly IMeetupApi _Api;

        public CitiesController(IMeetupApi _api)
        {
            _Api = _api;
        }

        public IActionResult Index()
        {
            var cities = _Api.GetCities().Result;

            var model = new CitiesViewModel { Cities = cities.Results };
            return View(model);
        }

        [HttpPost]
        public IActionResult Search([FromForm] CitiesQueryParams query)
        {
            var cities = _Api.SearchCities(query).Result;
            var model = new CitiesViewModel { Cities = cities.Results };
            return View("Index", model);
        }
    }
}
