using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using www.Data;
using www.Models;

namespace www.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var youtubeFeed = new RssFeed("https://www.reddit.com/r/younknow/.rss");
            ViewBag.rss = youtubeFeed.Items.Take(5);
            var newsFeed = new RssFeed("https://www.reddit.com/r/news/.rss");
            ViewBag.rss2 = newsFeed.Items.Take(5);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
