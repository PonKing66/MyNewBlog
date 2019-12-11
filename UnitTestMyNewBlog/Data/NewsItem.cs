using System;
using System.Collections.Generic;
using System.Text;

namespace TestXml
{
    public class NewsItem
    {
        public string title { get; set; }
        public string desc { get; set; }
        public string link { get; set; }
        public string author { get; set; }
        public string date { get; set; }

        public NewsItem()
        {
        }

        public NewsItem(string title, string desc, string link, string author, string date)
        {
            this.title = title;
            this.desc = desc;
            this.link = link;
            this.author = author;
            this.date = date;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
