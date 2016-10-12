using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast_ProjektB
{
    class Podcast
    {
        private string path;
        private string subject;
        private string summary;
        private string releaseDate;

        public Podcast(string path, string subject, string summary, string releaseDate)
        {
            this.path = path;
            this.subject = subject;
            this.summary = summary;
            this.releaseDate = releaseDate;
        }

        public string getPath()
        {
            return path;
        }
        public string getSubject()
        {
            return subject;
        }
        public string getSummary()
        {
            return summary;
        }
        public string getReleaseDate()
        {
            return releaseDate;
        }
    }
}
