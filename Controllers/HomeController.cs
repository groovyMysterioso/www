using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using www.Models;

namespace www.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var url = "https://www.youtube.com/feeds/videos.xml?channel_id=UCma2-ifEBQPrbtoNQuyYOYg";
            using (var reader = XmlReader.Create(url))
            {

                var feed = SyndicationFeed.Load(reader);
                ViewBag.rss = feed.Items.Take(5);
            }
            url = "https://www.reddit.com/r/news/.rss";
            using (var reader2 = XmlReader.Create(url))
            { 
                var feed2 = SyndicationFeed.Load(reader2);
            ViewBag.rss2 = feed2.Items.Take(5);
            }
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
