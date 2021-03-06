﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using BehaviorAgency.Host.Core;

namespace BehaviorAgency.Host.Controllers.Web
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly string _indexHtmlSourcePath;

        public HomeController(IConfiguration config) {
            _indexHtmlSourcePath = config.GetSection("GeneratedHtmlPath").Value;
        }

        public IActionResult Index()
        {
            InjectHtmlResources();

            return View();
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }

        private void InjectHtmlResources() {
            var htmlHandler = new HtmlAgilityPackHandler(_indexHtmlSourcePath);
            ViewBag.Links = htmlHandler.Links;
            ViewBag.Styles = htmlHandler.Styles;
            ViewBag.Scripts = htmlHandler.Scripts;
        }

    }
}
