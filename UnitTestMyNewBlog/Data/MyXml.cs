using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace TestXml
{

    class MyXml
    {
        public List<NewsItem> GetNewItems(String path)
        {
            List<NewsItem> newItems = new List<NewsItem>();
            //初始化一个xml实例
            XmlDocument xml = new XmlDocument();

            //导入指定xml文件
            xml.Load(path);
            //xml.Load(HttpContext.Current.Server.MapPath("~/file/bookstore.xml"));

            //获取同名同级节点集合
            XmlNodeList nodelist = xml.SelectNodes("rss/channel/item");
            foreach(XmlNode xn in nodelist)
            {

                
                //Console.WriteLine(xn.Attributes["number"].Value);
                string title = xn.SelectSingleNode("title").InnerText;
                string link = xn.SelectSingleNode("link").InnerText;
                string pubDate = xn.SelectSingleNode("pubDate").InnerText;
                //string author = xn.SelectSingleNode("author").InnerText;
                string  desc = xn.SelectSingleNode("description").InnerText;
                NewsItem newItem = new NewsItem(title,desc,link,null,pubDate);
                newItems.Add(newItem);
                Console.WriteLine(xn.InnerText);
            }
            return newItems;
        }


        public NewsInfo getNewsInfo(String path)
        {
            //初始化一个xml实例
            XmlDocument xml = new XmlDocument();

            //导入指定xml文件
            xml.Load(path);
            //xml.Load(HttpContext.Current.Server.MapPath("~/file/bookstore.xml"));

            //获取同名同级节点集合
            XmlNode xnTitle = xml.SelectSingleNode("rss/channel/title");
            XmlNode xnDesc = xml.SelectSingleNode("rss/channel/description");
            XmlNode xnLink = xml.SelectSingleNode("rss/channel/link");
            XmlNode xnlanguage = xml.SelectSingleNode("rss/channel/language");
            XmlNode xnGen = xml.SelectSingleNode("rss/channel/generator");
            XmlNode xnCopy = xml.SelectSingleNode("rss/channel/copyright");
            XmlNode xnDate = xml.SelectSingleNode("rss/channel/pubDate");
            NewsInfo newsInfo = new NewsInfo(xnTitle.InnerText,xnDesc.InnerText,xnLink.InnerText
                ,xnlanguage.InnerText,xnGen.InnerText,xnCopy.InnerText,new DateTime());
            return newsInfo;
        }

        public NewsInfo getNewsItemsTest(String xmlfile)
        {
            //判定xml文件存在
            if (File.Exists(xmlfile))
            {
                List<NewsItem> news = new List<NewsItem>();
    
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlfile);
                XElement root = xd.Root;
                //获取根节点下所有子节点
                IEnumerable<XElement> xe = root.Descendants("item");
                foreach (XElement fxe in xe)
                {
                    foreach (XElement sxe in fxe.Elements())
                    {
                       
                    }
                }
            }
            return null;
        }

    }
}
