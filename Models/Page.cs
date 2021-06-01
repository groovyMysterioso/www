using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace www.Models
{
    public class Page
    {
        public int Id { get; set; }
        public Profile Profile { get; set; }
        public string Category { get; set; }
        public RssFeed RssFeeds { get; set; }

        public Page()
        {}
    public static Page PersonalPage()
    {
        return new Page();
    }

    }
}
