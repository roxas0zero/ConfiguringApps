using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ConfiguringApps.Infrastructure;
using System;
using Microsoft.Extensions.Logging;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly UptimeService uptime;
        private readonly ILogger<HomeController> logger;

        public HomeController(UptimeService uptime, ILogger<HomeController> logger)
        {
            this.uptime = uptime;
            this.logger = logger;
        }

        public IActionResult Index(bool throwException = false)
        {
            logger.LogDebug($"Handled {Request.Path} at uptime {uptime.Uptime}ms");

            if (throwException)
            {
                throw new NullReferenceException();
            }

            var model = new Dictionary<string, string>
            {
                ["Message"] = "This is the Index action",
                ["Uptime"] = $"{uptime.Uptime}ms"
            };

            return View(model);
        }

        public IActionResult Error()
        {
            var model = new Dictionary<string, string>
            {
                ["Message"] = "This is Error action"
            };

            return View(model);
        }
    }
}