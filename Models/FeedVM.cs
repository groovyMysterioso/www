using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace www.Models
{
    public class FeedEntry
    {
        [Key]
        public int Id { get; set; }
        public string UrlLink { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public FeedEntry(SyndicationItem syndicationItem)
        {
            UrlLink = syndicationItem.Links[0].Uri.OriginalString;
            Title = syndicationItem.Title.Text;
            ContentText = syndicationItem.Content.ToString();
        }
        public FeedEntry() { }

    }
    public class FeedVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string UserID { get; set; }
        public FeedEntry[] ContentLinks { get; set; }

        public FeedVM(Feed feed) {
            var url = feed.Url;
            using (var reader = XmlReader.Create(url))
            {
                var rssFeed = SyndicationFeed.Load(reader);
                var ContentLinks = rssFeed.Items;
            }
        }
        public FeedVM() { }

    }
}
