using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataDrivenDiversity.Api;
using DataDrivenDiversity.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace DataDrivenDiversity.Controllers.Categories
{
    public class CategoriesController : Controller
    {
        private readonly IMeetupApi _Api;

        public CategoriesController(IMeetupApi _api)
        {
            _Api = _api;
        }

        public IActionResult Index()
        {
            var categories = _Api.GetCategories().Result;

            var model = new CategoriesViewModel { Categories = categories.Results };
            return View(model);
        }
    }
}
