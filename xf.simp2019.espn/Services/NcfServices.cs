using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using xf.simp2019.espn.Models;

namespace xf.simp2019.espn.Services
{
    public class NcfServices
    {
        Uri URL_RSS;
        private readonly WebClient webClient;
        public event EventHandler<GenericEventArgs<List<Article>>> GetArticles_Completed;

        public NcfServices()
        {
            URL_RSS = new Uri("https://www.espn.com/espn/rss/ncf/news");
            webClient = new WebClient();
        }

        public void GetArticles()
        {
            webClient.DownloadStringCompleted += (s, a) =>
            {
                try
                {
                    var resultString = a.Result;
                    var xdocument = XDocument.Parse(resultString);

                    var listOfNews = (from news in xdocument.Descendants("channel").Elements("item")
                                      select new Article
                                      {
                                          Title = news.Element("title").Value,
                                          Description = news.Element("description").Value,
                                          UrlImage = news.Element("image").Value,
                                          Link = news.Element("link").Value
                                      }).ToList();
                    GetArticles_Completed?.Invoke(this, new GenericEventArgs<List<Article>>(listOfNews));
                }
                catch { }
            };

            webClient.DownloadStringAsync(URL_RSS);
        }
    }
}