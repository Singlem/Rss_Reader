using System.Collections.Generic;

namespace RssReader.Domain.Models
{
    public class RssFeedContent
    {
        public string FeedTitle { get; set; }

        public IEnumerable<RssArticle> Articles { get; set; }
    }
}