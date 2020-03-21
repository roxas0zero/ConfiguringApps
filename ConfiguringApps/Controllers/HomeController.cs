using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ConfiguringApps.Infrastructure;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly UptimeService uptime;

        public HomeController(UptimeService uptime)
        {
            this.uptime = uptime;
        }

        public IActionResult Index()
        {
            var model = new Dictionary<string, string>
            {
                ["Message"] = "This is the Index action",
                ["Uptime"] = $"{uptime.Uptime}ms"
            };
            return View(model);
        }
    }
}