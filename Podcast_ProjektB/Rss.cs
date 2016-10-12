using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;


namespace Podcast_ProjektB
{
    class Rss
    {
        private string name;
        private string url;
        private string description;
        public Rss(string url, string name)
        {
            this.url = "http://alexosigge.libsyn.com/rss";
            this.name = name;
        }

        public List<Podcast> getFeed()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.MaxCharactersFromEntities = 1024;
            XmlReader reader = XmlReader.Create(url, settings);
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
