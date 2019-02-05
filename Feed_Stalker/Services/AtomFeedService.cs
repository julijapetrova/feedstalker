using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Feed_Stalker.Services
{

    public class AtomFeedService : FeedReaderService
    {
        
        private List<SyndicationFeed> syndicationFeeds = new List<SyndicationFeed>();

       
        public void RegisterFeed(string url)
        {
            XmlReader reader = XmlReader.Create("https://news.google.com/atom");
            syndicationFeeds.Add(SyndicationFeed.Load(reader));
        }

        public SyndicationFeed GetFeed()
        {
            XmlReader reader = XmlReader.Create("https://news.google.com/atom");
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            return feed;
        }

        public void RemoveFeed(SyndicationFeed feed)
        {
            syndicationFeeds.Remove(feed);
        }


    }

}