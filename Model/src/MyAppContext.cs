using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace Model
{
    public class RssFeedItem
    {
        public string Title { get; set; }
        public string Excerpt { get; set; }

        public RssFeedItem(string title, string excerpt)
        {
            Title = title;
            Excerpt = excerpt;
        }
    }

    public class RssFeedService
    {
        public async Task<List<RssFeedItem>> Load()
        {
            List<RssFeedItem> list = new List<RssFeedItem>();
            WebClient client = new WebClient();
            string data = client.DownloadString("https://lenta.ru/rss/news");
            XmlReader reader = XmlReader.Create(new StringReader(data));
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            Console.WriteLine(feed.Title.Text);
            Console.WriteLine("Items:");
            foreach (SyndicationItem item in feed.Items)
            {
                /*Console.WriteLine("Title: {0}", item.Title.Text);
                Console.WriteLine("Summary: {0}", (item.Summary).Text);*/
                list.Add(new RssFeedItem($"{item.Title}", $"{item.Summary}"));
            }
            return list;
        }
    }
    
    public class MyAppContext
    {
        public static readonly RssFeedService FeedService = new RssFeedService();
    }
}