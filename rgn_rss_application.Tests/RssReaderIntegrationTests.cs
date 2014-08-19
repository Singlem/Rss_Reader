using NUnit.Framework;
using RssReader.Domain.Repositories;

namespace rgn_rss_application.Tests
{
    [TestFixture]
    public class RssReaderIntegrationTests
    {
        [Test]
        public void ReaderCanRetrieveData()
        {
            var reader = new RssReaderRepository();
            var result = reader.ReadFeed("http://feeds.news24.com/articles/news24/TopStories/rss");

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Articles);
        }
    }
}
