using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.Services
{
    public class CoinHistory
    {
        public ObservableCollection<decimal> priceUSDList;
        public ObservableCollection<DateTime> timeList;

        public class CoinDataHistory
        {
            public string priceUsd { get; set; }
            public object time { get; set; }
            public DateTime date { get; set; }
        }

        public class CoinHistoryRoot
        {
            public List<CoinDataHistory> data { get; set; }
            public long timestamp { get; set; }
        }


        public CoinHistory(string coin, string interval)
        {
            CoinHistoryRoot coinHistoryRoot = new CoinHistoryRoot();
            using (var webClient = new WebClient())
            {
                string link = "https://api.coincap.io/v2/assets/" + coin + "/history?interval=" + interval;
                var jsonString = webClient.DownloadString(link);
                var valueSet = JsonConvert.DeserializeObject<CoinHistoryRoot>(jsonString);
                coinHistoryRoot = valueSet;
            }
            priceUSDList = new ObservableCollection<decimal>();
            timeList = new ObservableCollection<DateTime>();
            foreach (CoinDataHistory x in coinHistoryRoot.data)
            {
                priceUSDList.Add(Convert.ToDecimal(x.priceUsd, CultureInfo.InvariantCulture));
                timeList.Add(x.date);
            }
        }
    }
}
