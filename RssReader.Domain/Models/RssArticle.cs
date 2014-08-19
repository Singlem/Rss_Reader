using System;

namespace RssReader.Domain.Models
{
    public class RssArticle
    {
        public Uri Link { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
    }
}