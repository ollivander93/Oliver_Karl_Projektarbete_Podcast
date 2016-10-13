using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Podcast_ProjektB
{
    class Datalager
    {
        public Datalager()
        {
            
        }

        public XmlReader getRssFeed(string url)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.MaxCharactersFromEntities = 1024;
            XmlReader reader = XmlReader.Create(url, settings);
            return reader;
        }
        
        public XmlDocument getXmlDocument(string path)
        {
            XmlDocument document = new XmlDocument();
            document.Load(path);
            return document;
        }

        public XDocument getXdocument(string path)
        {
            XDocument document = XDocument.Load(path);
            return document;
        }
    }
}
