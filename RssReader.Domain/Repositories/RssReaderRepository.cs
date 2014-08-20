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
            if (feed.Resource is RssFeed)
            {
                return ReadRssFeed((RssFeed)feed.Resource);
            }

            if (feed.Resource is AtomFeed)
            {
                return ReadAtomFeed((AtomFeed)feed.Resource);
            }

            throw new InvalidOperationException("Feed has unsupported format");
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

        private RssFeedContent ReadAtomFeed(AtomFeed feed)
        {
            var rssContentModel = new RssFeedContent
            {
                FeedTitle = feed.Title.Content,
                Articles = feed.Entries.Select(item =>
                {
                    var firstOrDefault = item.Links.FirstOrDefault();
                    return firstOrDefault != null ? new RssArticle
                                                           {
                                                               Title = item.Title.Content,
                                                               Content = item.Content.Content,
                                                               PublicationDate = item.PublishedOn,
                                                               Link = firstOrDefault.Uri,
                                                               Author = string.Join(", ", item.Authors.Select(a => a.Name))
                                                           } : null;
                })
            };

            return rssContentModel;
        }
    }
}
