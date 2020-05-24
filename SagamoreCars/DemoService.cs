using HtmlAgilityPack;
using System;
using System.Threading;

namespace SagamoreCarsParser
{
    internal class DemoService : IDemoService
    {
        public void StartSetupDB()
        {
            var page = 0;
            var url = @"https://cars.av.by/honda/civic/page/" + page;

            while (true)
            {
                url = url.Substring(0, url.Length - (page++).ToString().Length) + page;
                var isContinue = ParseAnnouncements(url);
                if (!isContinue)
                    break;
            }
        }

        private bool ParseAnnouncements(string url)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(url);

            var isContinue = true;

            var web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            var allAnnouncements = htmlDoc.DocumentNode
                .SelectNodes("//div[@class = 'listing-wrap']/div[contains(@class, 'listing-item')]");

            if (allAnnouncements.Count < 25)
                isContinue = false;

            foreach (var announcement in allAnnouncements)
            {
                var s = announcement
                    .SelectSingleNode(".//div[@class = 'listing-item-image-in']/a")
                    .GetAttributeValue("href", string.Empty);

                Console.WriteLine(s);
                Thread.Sleep(50);
            }
            return isContinue;
        }
    }
}
