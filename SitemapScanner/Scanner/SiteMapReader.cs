using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XPath;

namespace SitemapScanner.Scanner
{
    public class SiteMapReader
    {
        public List<string> UrlList { get; set; }

        private List<string> innerSiteMapUrlList { get; set; }

        public SiteMapReader()
        {
            UrlList = new List<string>();
            innerSiteMapUrlList = new List<string>();
        }
        public IEnumerable<string> GetUrls(string url)
        {

            XmlReader xmlReader = !url.Contains("xml") ? new XmlTextReader(string.Format("http://{0}/sitemap.xml", url)) : new XmlTextReader(url);

            var xmlDoc = new XmlDocument();
            var xmlns = new XmlNamespaceManager(xmlDoc.NameTable);
            xmlns.AddNamespace("default", "http://www.sitemaps.org/schemas/sitemap/0.9");
            xmlDoc.Load(xmlReader);

            List<string> locs = xmlDoc.SelectNodes("//default:loc", xmlns)
                .OfType<XmlElement>()
                .Select(element => element.InnerText)
                .ToList();

           
            locs.ForEach(loc => parseUrlAddress(loc));
            innerSiteMapUrlList.ForEach(loc => GetUrls(loc));

            return UrlList;
        }

        private void parseUrlAddress(string loc)
        {
            if (loc.Contains("xml"))
            {
                innerSiteMapUrlList.Add(loc);
            }
            else
            {
                UrlList.Add(loc);
            }
        }
    }
}