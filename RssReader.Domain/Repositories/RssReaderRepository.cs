using System;
using System.Linq;
using Argotic.Syndication;
using RssReader.Domain.Models;

namespace RssReader.Domain.Repositories
{
    public class RssReaderRepository
    {
        public RssFeedContent ReadFeed(string feedUrl)
        {
            var feed = GenericSyndicationFeed.Create(new Uri(feedUrl));
            return ReadRssFeed((RssFeed)feed.Resource);
        }

        private static RssFeedContent ReadRssFeed(RssFeed feed)
        {
            var rssContentModel = new RssFeedContent
            {
                FeedTitle = feed.Channel.Title,
                Articles = feed.Channel.Items.Select(item => new RssArticle
                {
                    Title = item.Title,
                    Content = item.Description,
                    PublicationDate = item.PublicationDate,
                    Link = item.Link,
                    Author = item.Author
                })
            };

            return rssContentModel;
        }
    }
}
