using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;


namespace Podcast_ProjektB
{
    class RssHanterare
    {
        private Datalager data;
        private string name;
        private string url;
        private string description;
        public RssHanterare(string url, string name)
        {
            this.url = "http://api.sr.se/api/rss/program/4845";
            this.name = name;
            data = new Datalager();
        }

        public List<Podcast> getFeed()
        {
            XmlReader reader = data.getRssFeed(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            List<Podcast> podCastList = new List<Podcast>();
            foreach(SyndicationItem podcast in feed.Items)
            {
                string subject = podcast.Title.Text;
                string summary = podcast.Summary.Text;
                string release = podcast.PublishDate.ToString();
                string link = podcast.Links[0].Uri.AbsoluteUri;
                Podcast podcastObject = new Podcast(link, subject, summary, release);
                podCastList.Add(podcastObject);
            }
            return podCastList;
        }
    }
}
