using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Diagnostics;

namespace SitemapScanner.Scanner
{
    public class PageTimeResponse
    {
        public string ExecuteTest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            System.Diagnostics.Stopwatch timer = new Stopwatch();
            timer.Start();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            var timeString = string.Format("{0} {1}", timeTaken.TotalMilliseconds, "ms");

            return timeString;
        }
    }
}