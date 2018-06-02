using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BehaviorAgency.Host.Models;
using Microsoft.Extensions.Configuration;
using BehaviorAgency.Host.Utils;

namespace BehaviorAgency.Host.Controllers.Web
{
    public class HomeController : Controller
    {
        private readonly string _indexHtmlSourcePath;

        public HomeController(IConfiguration config) {
            _indexHtmlSourcePath = config.GetSection("GeneratedHtmlPath").Value;
        }

        public IActionResult Index()
        {
            Prepare();

            return View();
        }

        private void Prepare() {
            var htmlHelper = new HtmlAgilityPackHelper(_indexHtmlSourcePath);
            ViewBag.Links = htmlHelper.Links;
            ViewBag.Styles = htmlHelper.Styles;
            ViewBag.Scripts = htmlHelper.Scripts;
        }

    }
}
