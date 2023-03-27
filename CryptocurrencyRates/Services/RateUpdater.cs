using CryptocurrencyRates.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static CryptocurrencyRates.Services.CoinUpdater;

namespace CryptocurrencyRates.Services
{
    public class RateUpdater
    {
        IRateService rateService = new RateService();
        public class Datum
        {
            public string id { get; set; }
            public string symbol { get; set; }
            public string currencySymbol { get; set; }
            public string type { get; set; }
            public string rateUsd { get; set; }
        }
        public class Root
        {
            public List<Datum> data { get; set; }
            public long timestamp { get; set; }
        }

        public RateUpdater()
        {
            Root root;
            using (var webClient = new WebClient())
            {
                var jsonString = webClient.DownloadString("https://api.coincap.io/v2/rates");
                var valueSet = JsonConvert.DeserializeObject<Root>(jsonString);
                root = valueSet;
            }
            rateService.RemoveAllRate();
            var rateList = rateService.GetRate();
            foreach (Datum frate in root.data)
            {
                if (rateList.Any(c => c.sId == frate.id) == false)
                {
                    Rate rate = new Rate()
                    {
                        sId = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(frate.id.Replace("-", " ").ToLower()),
                        symbol = frate.symbol,
                        currencySymbol = frate.currencySymbol,
                        type = frate.type,
                        rateUsd = frate.rateUsd.Remove(frate.rateUsd.Length-8)

                    };
                    rateService.AddRate(rate);
                }
            }
        }
    }
}
