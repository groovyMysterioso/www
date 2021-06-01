using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace www.Models
{
    public class RssFeed : SyndicationFeed
    {
        public RssFeed(string url)
        {
            using (var reader = XmlReader.Create(url))
            {

                var feed = SyndicationFeed.Load(reader);
                Description = feed.Description;
                Items = feed.Items;
            }
        }
        public RssFeed(SyndicationFeed feed) { }
        public RssFeed(IEnumerable<SyndicationItem> items) : base(items)
        {
        }

        public RssFeed(string title, string description, Uri feedAlternateLink) : base(title, description, feedAlternateLink)
        {
        }

        public RssFeed(string title, string description, Uri feedAlternateLink, IEnumerable<SyndicationItem> items) : base(title, description, feedAlternateLink, items)
        {
        }

        public RssFeed(string title, string description, Uri feedAlternateLink, string id, DateTimeOffset lastUpdatedTime) : base(title, description, feedAlternateLink, id, lastUpdatedTime)
        {
        }

        public RssFeed(string title, string description, Uri feedAlternateLink, string id, DateTimeOffset lastUpdatedTime, IEnumerable<SyndicationItem> items) : base(title, description, feedAlternateLink, id, lastUpdatedTime, items)
        {
        }

        protected RssFeed(SyndicationFeed source, bool cloneItems) : base(source, cloneItems)
        {
        }
    }
}
