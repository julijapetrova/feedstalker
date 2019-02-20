using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace Feed_Stalker.Services
{

    public class AtomFeedService : FeedReaderService
    {

        private Dictionary<string, SyndicationFeed> syndicationFeeds = new Dictionary<string, SyndicationFeed>();


        public SyndicationFeed GetFeed(string secretkey)
        {

            if (syndicationFeeds.ContainsKey(secretkey))
            {
                return syndicationFeeds[secretkey];
            }
            else
            {
                return null;
            }
        }


        public string createAtomFeed(string title, string description, string uri)
        {
            SyndicationFeed feed = new SyndicationFeed(title, description, new Uri(uri));

            string secretKey = Guid.NewGuid().ToString();

            syndicationFeeds.Add(secretKey, feed);

            return secretKey;
        }

        public void editAtomFeedUri(string secretkey, string newUri)
        {
            if (syndicationFeeds.ContainsKey(secretkey))
            {
                syndicationFeeds[secretkey].BaseUri = new Uri(newUri);
            }
        }

        public void RemoveFeed(string secretkey)
        {
            if (syndicationFeeds.ContainsKey(secretkey))
            {
                syndicationFeeds.Remove(secretkey);
            }
        }

        
    }

}