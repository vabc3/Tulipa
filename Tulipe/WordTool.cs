using System;
using System.Data.Services.Client;
using System.Net;
using Tulipe.bsc.Bing;

namespace Tulipe
{
    public class WordTool
    {
        public void GetRelated()
        {
            var svc = new BingSearchContainer(new Uri("https://api.datamarket.azure.com/Bing/Search/"));

            var accountKey = "eA6zUvLadgzgTeMMkur1Kz4dwC3YuHsfjmyX2dPsfw4";

            // the next line configures the bingContainer to use your credentials.
            svc.Credentials = new NetworkCredential(accountKey, accountKey);
            var result = svc.Execute<RelatedSearchResult>(
                 new Uri("https://api.datamarket.azure.com/Bing/Search/RelatedSearch"),
                 "GET",
                 false,
                 new UriOperationParameter("Query", "狮驼岭"));


             foreach(var dat in result)
            {
                Console.WriteLine(dat.Title);
            }
        }
    }
}
