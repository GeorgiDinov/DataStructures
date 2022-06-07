using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace DataStructures
{
    internal class BFSWebCrawler
    {

        // contains the URL's e.g. www.bbc.com, www.facebook.com
        private Queue<string> webSiteQueue;
        private List<string> discoveredWebSiteList;

        public BFSWebCrawler()
        {
            this.webSiteQueue = new Queue<string>();
            this.discoveredWebSiteList = new List<string>();
        }



        public void crawlTheWebFrom(string startingUrl)
        {
            webSiteQueue.Enqueue(startingUrl);
            discoveredWebSiteList.Add(startingUrl);

            while (webSiteQueue.Count > 0)
            {
                string currentUrl = webSiteQueue.Dequeue();
                string rawHtml = ReadUrl(currentUrl);

                Regex regex = new Regex("(?<url>https://(\\w+\\.)*(\\w+))");
                MatchCollection matchCollection = regex.Matches(rawHtml);

                if (matchCollection.Count > 0)
                {
                    foreach (Match match in matchCollection)
                    {
                        string url = match.Groups["url"].Value;
                        if (!discoveredWebSiteList.Contains(url))
                        {
                            discoveredWebSiteList.Add(url);
                            Console.WriteLine("Visiting website: " + url);
                            webSiteQueue.Enqueue(url);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found...");
                }
            }
        }


        private string ReadUrl(string url)
        {
            string rawHTML = "";

            try
            {
                // Create a request for the URL.
                WebRequest request = WebRequest.Create(url);
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // Display the status.
                Console.WriteLine(response.StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                rawHTML = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(rawHTML);
                // Cleanup the streams and the response.
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Problem while crawling " + url);
            }

            return rawHTML;
        }

    }
}
