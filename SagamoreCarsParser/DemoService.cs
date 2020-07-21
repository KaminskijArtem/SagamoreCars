using HtmlAgilityPack;
using SagamoreCarsApiSDK;
using System;
using System.Threading;

namespace SagamoreCarsParser
{
    internal class DemoService : IDemoService
    {
        public SagamoreCarsApiClient apiClient = new SagamoreCarsApiClient();
        public void StartSetupDB()
        {
            var page = 0;
            var url = $"https://cars.av.by/search/page/--page--?year_from=&year_to=&currency=USD&price_from=&price_to=&body_id=&engine_volume_min=&engine_volume_max=&driving_id=&mileage_min=&mileage_max=&region_id=&interior_material=&interior_color=&exchange=&search_time=";

            while (true)
            {
                //url = url.Substring(0, url.Length - (page++).ToString().Length) + page;
                page++;
                if (!ParseAnnouncements(url.Replace("--page--", page.ToString())))
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

            if (allAnnouncements.Count < 20)
                isContinue = false;

            foreach (var announcement in allAnnouncements)
            {
                var href = announcement.SelectSingleNode(".//div[@class = 'listing-item-image-in']/a")
                    .GetAttributeValue("href", string.Empty);
                var year = announcement.SelectSingleNode(".//div[@class = 'listing-item-price']/span").InnerText;
                var cost = announcement.SelectSingleNode(".//div[@class = 'listing-item-price']/small").InnerText
                    .Replace(" ", string.Empty);

                try
                {
                    var existingCarAd = apiClient.GetAsync(href).Result;
                    Console.WriteLine(@"- {0}", existingCarAd.Href);
                }
                catch (AggregateException ex)
                {
                    var innerException = (ApiException)ex.InnerException;
                    if (innerException.StatusCode == 404)
                        AddNewCarAd(href, year, cost);
                    else
                        throw;
                }
            }
            return isContinue;
        }

        private void AddNewCarAd(string href, string year, string cost)
        {
            var carAd = new CarAd()
            {
                Href = href,
                Cost = int.Parse(cost),
                Year = int.Parse(year)
            };

            apiClient.PostAsync(carAd).GetAwaiter();

            Console.WriteLine(@"{0} {1} {2} Imported", href, year, cost);
            //Thread.Sleep(300);
        }
    }
}
