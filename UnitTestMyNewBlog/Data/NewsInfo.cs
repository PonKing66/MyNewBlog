using System;
using System.Collections.Generic;
using System.Text;

namespace TestXml
{
    class NewsInfo
    {
        public string title { get; set; }
        public string desc { get; set; }
        public string link { get; set; }
        public string language { get; set; }
        public string generator { get; set; }

        public string copyright { get; set; }
        public DateTime date { get; set; }

        public NewsInfo()
        {
        }

        public NewsInfo(string title, string desc, string link, string language, string generator, string copyright, DateTime date)
        {
            this.title = title;
            this.desc = desc;
            this.link = link;
            this.language = language;
            this.generator = generator;
            this.copyright = copyright;
            this.date = date;
        }
    }
}
