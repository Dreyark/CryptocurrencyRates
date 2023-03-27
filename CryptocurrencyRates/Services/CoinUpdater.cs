using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CryptocurrencyRates.Models;
using CryptocurrencyRates.Services;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace CryptocurrencyRates.Services
{
    public class CoinUpdater
    {
        ICryptocurrencyService cryptocurrencyService = new CryptocurrencyService();
        Root Coins = new Root();
        public class Datum
        {
            public string id { get; set; }
            public string rank { get; set; }
            public string symbol { get; set; }
            public string name { get; set; }
            public string supply { get; set; }
            public string maxSupply { get; set; }
            public string marketCapUsd { get; set; }
            public string volumeUsd24Hr { get; set; }
            public string priceUsd { get; set; }
            public string changePercent24Hr { get; set; }

        }

        public class Root
        {
            public List<Datum> data { get; set; }
            public long timestamp { get; set; }
        }

        public CoinUpdater()
        {
            using (var webClient = new WebClient())
            {
                var jsonString = webClient.DownloadString("https://api.coincap.io/v2/assets?limit=100");
                var valueSet = JsonConvert.DeserializeObject<Root>(jsonString);
                Coins = valueSet;
            }
            cryptocurrencyService.RemoveAllCryptocurrency();
            var Cryptolist = cryptocurrencyService.GetCrypto();
            foreach (Datum coin in Coins.data)
            {
                if (Cryptolist.Any(c=>c.Name == coin.name) == false)
                {
                    //using (WebClient client = new WebClient())
                    //{
                    //    var url = "https://assets.coincap.io/assets/icons/" + coin.symbol.ToLower() + "@2x.png";
                    //    client.DownloadFileAsync(new Uri(url), @"C:\Users\Dreyark\source\repos\Dreyark\CryptocurrencyRates\CryptocurrencyRates\Resources\CoinIcon\" + coin.symbol.ToLower() + ".png");
                    //}
                    Cryptocurrency crypto = new Cryptocurrency()
                    {
                        coinId = coin.id,
                        Name = coin.name,
                        Alias = coin.symbol,
                        //imgSRC = FileSystem.OpenAppPackageFileAsync + coin.symbol.ToLower() + ".png",
                        imgSRC = "https://assets.coincap.io/assets/icons/" + coin.symbol.ToLower() + "@2x.png",
                        CurrentRateUsd = coin.priceUsd,
                        supply = coin.supply,
                        maxSupply = coin.maxSupply,
                        marketCapUsd = coin.marketCapUsd,
                        changePercent24Hr = coin.changePercent24Hr
                    };
                    cryptocurrencyService.AddCrypto(crypto);
                }
            };
        }
    }
}
